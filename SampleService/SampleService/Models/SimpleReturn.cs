using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SampleService.Models
{
    [DataContract]
    public class SimpleReturn
    {
        [DataMember]
        public decimal Value;
    }
}