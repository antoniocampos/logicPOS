﻿using logicpos.datalayer.DataLayer.Xpo;
using logicpos.datalayer.Enums;
using logicpos.datalayer.Xpo;
using LogicPOS.Data.XPO.Settings;
using LogicPOS.Globalization;
using LogicPOS.Settings.Extensions;
using LogicPOS.Shared.Orders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static logicpos.datalayer.Xpo.XPOHelper;

namespace LogicPOS.Shared
{
    public class POSSession
    {
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string JsonFileLocation { get; set; }

        public DateTime SessionStartDate { get; set; }

        public DateTime SessionUpdatedAt { get; set; }
        public Dictionary<Guid, DateTime> LoggedUsers { get; set; }

        public Guid CurrentOrderMainId { get; set; }

        public Dictionary<Guid, OrderMain> OrderMains { get; set; }

        public Dictionary<string, object> Tokens { get; set; }
        private bool IsEmpty => OrderMains.Count == 0 && LoggedUsers.Count == 0;

        public POSSession(string jsonFileLocation)
        {
            JsonFileLocation = jsonFileLocation;
            CurrentOrderMainId = Guid.Empty;
            SessionStartDate = XPOHelper.CurrentDateTimeAtomic();
            LoggedUsers = new Dictionary<Guid, DateTime>();
            OrderMains = new Dictionary<Guid, OrderMain>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public void WriteToFile()
        {
            var contentsToWriteToFile = Serialize();
            var writer = new StreamWriter(JsonFileLocation, false);
            writer.Write(contentsToWriteToFile);
            writer.Close();
        }

        public void DeleteJsonFile()
        {
            if (File.Exists(JsonFileLocation)) File.Delete(JsonFileLocation);
        }

        public void Save()
        {
            if (HasCurrentSession && CurrentSession.IsEmpty)
            {
                DeleteJsonFile();
                return;
            }

            SessionUpdatedAt = XPOHelper.CurrentDateTimeAtomic();
            WriteToFile();
        }

        public void CleanSession()
        {
            DeleteLoggedUsers();
            DeleteEmptyTickets();
        }

        public void DeleteLoggedUsers()
        {
            foreach (Guid item in CurrentSession.LoggedUsers.Keys)
            {
                sys_userdetail user = (sys_userdetail)XPOHelper.GetXPGuidObject(typeof(sys_userdetail), item);
                XPOHelper.Audit("USER_loggerOUT", string.Format(CultureResources.GetResourceByLanguage(LogicPOS.Settings.CultureSettings.CurrentCultureName, "audit_message_used_forced_loggerout"), user.Name));
            }
            CurrentSession.LoggedUsers.Clear();
        }

        public void DeleteEmptyTickets()
        {
            Guid latestNonEmptyOrder = Guid.Empty;

            if (OrderMains != null && OrderMains.Count > 0)
            {
                //Used to store List of Items to Remove after foreach, we cant remove it inside a foreach
                List<Guid> removeItems = new List<Guid>();
                foreach (Guid orderIndex in OrderMains.Keys)
                {
                    //Remove if Not Open and if Dont have Lines
                    if (OrderMains[orderIndex].OrderStatus != OrderStatus.Open && OrderMains[orderIndex].OrderTickets[OrderMains[orderIndex].CurrentTicketId].OrderDetails.Lines.Count == 0)
                    {
                        removeItems.Add(orderIndex);
                    }
                    else
                    {
                        latestNonEmptyOrder = orderIndex;
                    }
                };
                foreach (var item in removeItems)
                {
                    OrderMains.Remove(item);
                    break;
                }
            }
            if (!CurrentSession.OrderMains.ContainsKey(CurrentSession.CurrentOrderMainId))
                CurrentSession.CurrentOrderMainId = latestNonEmptyOrder;
        }

        public bool SetToken(string pToken, object pValue)
        {
            bool result = false;

            try
            {
                //Init Dictionary
                if (Tokens == null) Tokens = new Dictionary<string, object>();
                //Update Token
                if (Tokens.ContainsKey(pToken))
                {
                    Tokens[pToken] = pValue;
                }
                //Add Token
                else
                {
                    Tokens.Add(pToken, pValue);
                }

                result = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return result;
        }

        public object GetToken(string pToken)
        {
            object result = null;

            try
            {
                if (Tokens != null && Tokens.Count > 0 && Tokens.ContainsKey(pToken)) result = Tokens[pToken];
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }

            return result;
        }

        #region Static
        public static POSSession GetSessionFromFile(string jsonFileLocation)
        {
            POSSession appSession;

            if (File.Exists(jsonFileLocation))
            {

                string jsonfileContents = File.ReadAllText(jsonFileLocation);
                appSession = JsonConvert.DeserializeObject<POSSession>(jsonfileContents);
                appSession.JsonFileLocation = jsonFileLocation;
            }
            else
            {
                appSession = new POSSession(jsonFileLocation);
                appSession.Save();
            }

            return appSession;
        }
        public static POSSession CurrentSession { get; set; }
        public static bool HasCurrentSession => CurrentSession != null;
        public static decimal GetGlobalDiscount()
        {
            decimal result = 0.0m;

            if (POSSession.HasCurrentSession
                && POSSession.CurrentSession.OrderMains.ContainsKey(POSSession.CurrentSession.CurrentOrderMainId)
            )
            {
                OrderMain orderMain = POSSession.CurrentSession.OrderMains[POSSession.CurrentSession.CurrentOrderMainId];

                pos_configurationplacetable xConfigurationPlaceTable = (pos_configurationplacetable)GetXPGuidObject(XPOSettings.Session, typeof(pos_configurationplacetable), orderMain.Table.Oid);

                if (xConfigurationPlaceTable != null)
                {
                    result = xConfigurationPlaceTable.Discount;
                }
            }

            return result;
        }
        #endregion
    }
}
