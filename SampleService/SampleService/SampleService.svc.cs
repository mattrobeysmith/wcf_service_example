using SampleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace SampleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SampleService : ISampleService
    {
        public string HelloWorld()
        {
            return string.Format("Hello World!");
        }

        public SimpleReturn SimpleOperation(SimpleObject simple)
        {
            if(!CheckKey(OperationContext.Current.IncomingMessageHeaders))
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = HttpStatusCode.Forbidden;
                response.StatusDescription = "Key not authenticated.";
                return null;
            }
            return simple.Type == SimpleEnum.One ? new SimpleReturn { Value = simple.Value * 1 } : new SimpleReturn { Value = simple.Value * 2 };
        }

        private bool CheckKey(MessageHeaders headers)
        {
            try
            {
                var keyHeader = headers.GetHeader<string>("Key", "");
                return keyHeader != null && keyHeader.Equals("1234");
            } catch
            {
                return false;
            }
        }
    }
}
