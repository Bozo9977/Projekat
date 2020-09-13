using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthTesting.AuthDbAccess
{
    [DataContract]
    public class ApplicationUserIM
    {
        [DataMember]
        public string ime { get; set; }
        [DataMember]
        public string prezime { get; set; }
        [DataMember]
        public string Uloga { get; set; }
        [DataMember]
        public string KorisnickoIme { get; set; }
        [DataMember]
        public bool FirstLogin { get; set; }
    }
}
