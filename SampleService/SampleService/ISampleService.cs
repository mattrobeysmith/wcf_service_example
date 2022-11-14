using SampleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleService
{
    [ServiceContract]
    public interface ISampleService
    {

        [OperationContract]
        [WebGet]
        string HelloWorld();

        [OperationContract]
        [WebGet]
        SimpleReturn SimpleOperation(SimpleObject simple);
    }
}
