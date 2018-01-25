﻿using Gtk;
using logicpos.App;
using logicpos.datalayer.DataLayer.Xpo;
using logicpos.Classes.Gui.Gtk.Widgets.BackOffice;
using logicpos.Classes.Gui.Gtk.WidgetsGeneric;
using logicpos.Classes.Gui.Gtk.WidgetsXPO;
using logicpos.resources.Resources.Localization;

namespace logicpos.Classes.Gui.Gtk.BackOffice
{
    class DialogConfigurationPrinters : BOBaseDialog
    {
        public DialogConfigurationPrinters(Window pSourceWindow, GenericTreeViewXPO pTreeView, DialogFlags pFlags, DialogMode pDialogMode, XPGuidObject pXPGuidObject)
            : base(pSourceWindow, pTreeView, pFlags, pDialogMode, pXPGuidObject)
        {
            this.Title = Utils.GetWindowTitle(Resx.window_title_edit_dialogconfigurationprinters);
            SetSizeRequest(500, 500 - 102);
            InitUI();
            InitNotes();
            ShowAll();
        }

        private void InitUI()
        {
            try
            {
                //Tab1
                VBox vboxTab1 = new VBox(false, _boxSpacing) { BorderWidth = (uint)_boxSpacing };

                //Ord
                Entry entryOrd = new Entry();
                BOWidgetBox boxLabel = new BOWidgetBox(Resx.global_record_order, entryOrd);
                vboxTab1.PackStart(boxLabel, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxLabel, _dataSourceRow, "Ord", SettingsApp.RegexIntegerGreaterThanZero, true));

                //Code
                Entry entryCode = new Entry();
                BOWidgetBox boxCode = new BOWidgetBox(Resx.global_record_code, entryCode);
                vboxTab1.PackStart(boxCode, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxCode, _dataSourceRow, "Code", SettingsApp.RegexIntegerGreaterThanZero, true));

                //Designation
                Entry entryDesignation = new Entry();
                BOWidgetBox boxDesignation = new BOWidgetBox(Resx.global_designation, entryDesignation);
                vboxTab1.PackStart(boxDesignation, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxDesignation, _dataSourceRow, "Designation", SettingsApp.RegexAlfa, true));

                //PrinterType
                XPOComboBox xpoComboBoxPrinterType = new XPOComboBox(DataSourceRow.Session, typeof(SYS_ConfigurationPrintersType), (DataSourceRow as SYS_ConfigurationPrinters).PrinterType, "Designation");
                BOWidgetBox boxPrinterType = new BOWidgetBox(Resx.global_printer_type, xpoComboBoxPrinterType);
                vboxTab1.PackStart(boxPrinterType, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxPrinterType, DataSourceRow, "PrinterType", SettingsApp.RegexGuid, true));

                //NetworkName
                Entry entryNetworkName = new Entry();
                BOWidgetBox boxNetworkName = new BOWidgetBox(Resx.global_networkname, entryNetworkName);
                vboxTab1.PackStart(boxNetworkName, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(boxNetworkName, _dataSourceRow, "NetworkName", SettingsApp.RegexAlfaNumericFilePath, false));

                //Disabled
                CheckButton checkButtonDisabled = new CheckButton(Resx.global_record_disabled);
                if (_dialogMode == DialogMode.Insert) checkButtonDisabled.Active = SettingsApp.BOXPOObjectsStartDisabled;
                vboxTab1.PackStart(checkButtonDisabled, false, false, 0);
                _crudWidgetList.Add(new GenericCRUDWidgetXPO(checkButtonDisabled, _dataSourceRow, "Disabled"));

                //Append Tab
                _notebook.AppendPage(vboxTab1, new Label(Resx.global_record_main_detail));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
            }
        }
    }
}
