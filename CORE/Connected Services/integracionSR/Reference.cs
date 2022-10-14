﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CORE.integracionSR {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://intec.edu.do", ConfigurationName="integracionSR.integracionSWSoap")]
    public interface integracionSWSoap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://intec.edu.do is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://intec.edu.do/HelloWorld", ReplyAction="*")]
        CORE.integracionSR.HelloWorldResponse HelloWorld(CORE.integracionSR.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://intec.edu.do/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<CORE.integracionSR.HelloWorldResponse> HelloWorldAsync(CORE.integracionSR.HelloWorldRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://intec.edu.do", Order=0)]
        public CORE.integracionSR.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(CORE.integracionSR.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://intec.edu.do", Order=0)]
        public CORE.integracionSR.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(CORE.integracionSR.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://intec.edu.do")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface integracionSWSoapChannel : CORE.integracionSR.integracionSWSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class integracionSWSoapClient : System.ServiceModel.ClientBase<CORE.integracionSR.integracionSWSoap>, CORE.integracionSR.integracionSWSoap {
        
        public integracionSWSoapClient() {
        }
        
        public integracionSWSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public integracionSWSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public integracionSWSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public integracionSWSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CORE.integracionSR.HelloWorldResponse CORE.integracionSR.integracionSWSoap.HelloWorld(CORE.integracionSR.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            CORE.integracionSR.HelloWorldRequest inValue = new CORE.integracionSR.HelloWorldRequest();
            inValue.Body = new CORE.integracionSR.HelloWorldRequestBody();
            CORE.integracionSR.HelloWorldResponse retVal = ((CORE.integracionSR.integracionSWSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CORE.integracionSR.HelloWorldResponse> CORE.integracionSR.integracionSWSoap.HelloWorldAsync(CORE.integracionSR.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<CORE.integracionSR.HelloWorldResponse> HelloWorldAsync() {
            CORE.integracionSR.HelloWorldRequest inValue = new CORE.integracionSR.HelloWorldRequest();
            inValue.Body = new CORE.integracionSR.HelloWorldRequestBody();
            return ((CORE.integracionSR.integracionSWSoap)(this)).HelloWorldAsync(inValue);
        }
    }
}