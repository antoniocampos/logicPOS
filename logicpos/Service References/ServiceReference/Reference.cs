﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace logicpos.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/logicpos.financial.servicewcf")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServicesATSoapResult", Namespace="http://schemas.datacontract.org/2004/07/logicpos.financial.service.Objects.Module" +
        "s.AT")]
    [System.SerializableAttribute()]
    public partial class ServicesATSoapResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATDocCodeIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReturnCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReturnMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReturnRawField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATDocCodeID {
            get {
                return this.ATDocCodeIDField;
            }
            set {
                if ((object.ReferenceEquals(this.ATDocCodeIDField, value) != true)) {
                    this.ATDocCodeIDField = value;
                    this.RaisePropertyChanged("ATDocCodeID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocumentNumber {
            get {
                return this.DocumentNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentNumberField, value) != true)) {
                    this.DocumentNumberField = value;
                    this.RaisePropertyChanged("DocumentNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReturnCode {
            get {
                return this.ReturnCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.ReturnCodeField, value) != true)) {
                    this.ReturnCodeField = value;
                    this.RaisePropertyChanged("ReturnCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReturnMessage {
            get {
                return this.ReturnMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ReturnMessageField, value) != true)) {
                    this.ReturnMessageField = value;
                    this.RaisePropertyChanged("ReturnMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReturnRaw {
            get {
                return this.ReturnRawField;
            }
            set {
                if ((object.ReferenceEquals(this.ReturnRawField, value) != true)) {
                    this.ReturnRawField = value;
                    this.RaisePropertyChanged("ReturnRaw");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        logicpos.ServiceReference.CompositeType GetDataUsingDataContract(logicpos.ServiceReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<logicpos.ServiceReference.CompositeType> GetDataUsingDataContractAsync(logicpos.ServiceReference.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendDocument", ReplyAction="http://tempuri.org/IService1/SendDocumentResponse")]
        logicpos.ServiceReference.ServicesATSoapResult SendDocument(System.Guid pDocumentMaster);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendDocument", ReplyAction="http://tempuri.org/IService1/SendDocumentResponse")]
        System.Threading.Tasks.Task<logicpos.ServiceReference.ServicesATSoapResult> SendDocumentAsync(System.Guid pDocumentMaster);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : logicpos.ServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<logicpos.ServiceReference.IService1>, logicpos.ServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public logicpos.ServiceReference.CompositeType GetDataUsingDataContract(logicpos.ServiceReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<logicpos.ServiceReference.CompositeType> GetDataUsingDataContractAsync(logicpos.ServiceReference.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public logicpos.ServiceReference.ServicesATSoapResult SendDocument(System.Guid pDocumentMaster) {
            return base.Channel.SendDocument(pDocumentMaster);
        }
        
        public System.Threading.Tasks.Task<logicpos.ServiceReference.ServicesATSoapResult> SendDocumentAsync(System.Guid pDocumentMaster) {
            return base.Channel.SendDocumentAsync(pDocumentMaster);
        }
    }
}
