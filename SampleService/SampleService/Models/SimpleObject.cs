using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SampleService.Models
{
    [DataContract]
    public class SimpleObject
    {
        [DataMember]
        public SimpleEnum Type;
        [DataMember]
        public decimal Value;
    }

    [DataContract(Name = "Simple")]
    public enum SimpleEnum
    {
        [EnumMember]
        One,
        [EnumMember]
        Two
    }
}