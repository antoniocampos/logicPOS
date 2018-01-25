using DevExpress.Xpo;
using logicpos.datalayer.App;
using System;

namespace logicpos.datalayer.DataLayer.Xpo
{
    [DeferredDeletion(false)]
    public class POS_ConfigurationKeyboard : XPGuidObject
    {
        public POS_ConfigurationKeyboard() : base() { }
        public POS_ConfigurationKeyboard(Session session) : base(session) { }

        protected override void OnAfterConstruction()
        {
            Ord = FrameworkUtils.GetNextTableFieldID("POS_ConfigurationKeyboard", "Ord");
            Code = FrameworkUtils.GetNextTableFieldID("POS_ConfigurationKeyboard", "Code");
        }

        UInt32 fOrd;
        public UInt32 Ord
        {
            get { return fOrd; }
            set { SetPropertyValue<UInt32>("Ord", ref fOrd, value); }
        }

        UInt32 fCode;
        [Indexed(Unique = true)]
        public UInt32 Code
        {
            get { return fCode; }
            set { SetPropertyValue<UInt32>("Code", ref fCode, value); }
        }

        string fDesignation;
        [Indexed(Unique = true)]
        public string Designation
        {
            get { return fDesignation; }
            set { SetPropertyValue<string>("Designation", ref fDesignation, value); }
        }

        string fLanguage;
        public string Language
        {
            get { return fLanguage; }
            set { SetPropertyValue<string>("Language", ref fLanguage, value); }
        }

        string fVirtualKeyboard;
        public string VirtualKeyboard
        {
            get { return fVirtualKeyboard; }
            set { SetPropertyValue<string>("VirtualKeyboard", ref fVirtualKeyboard, value); }
        }
    }
}