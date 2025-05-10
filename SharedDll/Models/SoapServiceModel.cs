using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SharedDll.Models
{
    [DataContract]
    public class SoapServiceModel
    {
        [DataMember]
        public int id{ get; set; }
        [DataMember]
        public string name { get; set; }
    }
}
