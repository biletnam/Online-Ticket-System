﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.TicketServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/TicketService")]
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TicketServiceRef.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        WebClient.TicketServiceRef.CompositeType GetDataUsingDataContract(WebClient.TicketServiceRef.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WebClient.TicketServiceRef.CompositeType> GetDataUsingDataContractAsync(WebClient.TicketServiceRef.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GenerateTicket", ReplyAction="http://tempuri.org/IService1/GenerateTicketResponse")]
        string GenerateTicket(string userId, string attractionName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GenerateTicket", ReplyAction="http://tempuri.org/IService1/GenerateTicketResponse")]
        System.Threading.Tasks.Task<string> GenerateTicketAsync(string userId, string attractionName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verifyTicket", ReplyAction="http://tempuri.org/IService1/verifyTicketResponse")]
        bool verifyTicket(string ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verifyTicket", ReplyAction="http://tempuri.org/IService1/verifyTicketResponse")]
        System.Threading.Tasks.Task<bool> verifyTicketAsync(string ticket);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getUserTicket", ReplyAction="http://tempuri.org/IService1/getUserTicketResponse")]
        string getUserTicket(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getUserTicket", ReplyAction="http://tempuri.org/IService1/getUserTicketResponse")]
        System.Threading.Tasks.Task<string> getUserTicketAsync(string userId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebClient.TicketServiceRef.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebClient.TicketServiceRef.IService1>, WebClient.TicketServiceRef.IService1 {
        
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
        
        public WebClient.TicketServiceRef.CompositeType GetDataUsingDataContract(WebClient.TicketServiceRef.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WebClient.TicketServiceRef.CompositeType> GetDataUsingDataContractAsync(WebClient.TicketServiceRef.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string GenerateTicket(string userId, string attractionName) {
            return base.Channel.GenerateTicket(userId, attractionName);
        }
        
        public System.Threading.Tasks.Task<string> GenerateTicketAsync(string userId, string attractionName) {
            return base.Channel.GenerateTicketAsync(userId, attractionName);
        }
        
        public bool verifyTicket(string ticket) {
            return base.Channel.verifyTicket(ticket);
        }
        
        public System.Threading.Tasks.Task<bool> verifyTicketAsync(string ticket) {
            return base.Channel.verifyTicketAsync(ticket);
        }
        
        public string getUserTicket(string userId) {
            return base.Channel.getUserTicket(userId);
        }
        
        public System.Threading.Tasks.Task<string> getUserTicketAsync(string userId) {
            return base.Channel.getUserTicketAsync(userId);
        }
    }
}
