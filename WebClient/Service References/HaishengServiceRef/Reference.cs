﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClient.HaishengServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HaishengServiceRef.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/addSpot", ReplyAction="http://tempuri.org/IService1/addSpotResponse")]
        bool addSpot(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/addSpot", ReplyAction="http://tempuri.org/IService1/addSpotResponse")]
        System.Threading.Tasks.Task<bool> addSpotAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getSpots", ReplyAction="http://tempuri.org/IService1/getSpotsResponse")]
        string getSpots();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getSpots", ReplyAction="http://tempuri.org/IService1/getSpotsResponse")]
        System.Threading.Tasks.Task<string> getSpotsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getWeatherForcast", ReplyAction="http://tempuri.org/IService1/getWeatherForcastResponse")]
        string[] getWeatherForcast(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getWeatherForcast", ReplyAction="http://tempuri.org/IService1/getWeatherForcastResponse")]
        System.Threading.Tasks.Task<string[]> getWeatherForcastAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getPOI", ReplyAction="http://tempuri.org/IService1/getPOIResponse")]
        string[] getPOI(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getPOI", ReplyAction="http://tempuri.org/IService1/getPOIResponse")]
        System.Threading.Tasks.Task<string[]> getPOIAsync(string zipcode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebClient.HaishengServiceRef.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebClient.HaishengServiceRef.IService1>, WebClient.HaishengServiceRef.IService1 {
        
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
        
        public bool addSpot(string json) {
            return base.Channel.addSpot(json);
        }
        
        public System.Threading.Tasks.Task<bool> addSpotAsync(string json) {
            return base.Channel.addSpotAsync(json);
        }
        
        public string getSpots() {
            return base.Channel.getSpots();
        }
        
        public System.Threading.Tasks.Task<string> getSpotsAsync() {
            return base.Channel.getSpotsAsync();
        }
        
        public string[] getWeatherForcast(string zipcode) {
            return base.Channel.getWeatherForcast(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> getWeatherForcastAsync(string zipcode) {
            return base.Channel.getWeatherForcastAsync(zipcode);
        }
        
        public string[] getPOI(string zipcode) {
            return base.Channel.getPOI(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> getPOIAsync(string zipcode) {
            return base.Channel.getPOIAsync(zipcode);
        }
    }
}
