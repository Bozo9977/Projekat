using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkolaPL.IntermediaryModels
{
    [DataContract]
    public class UcionicaIM
    {
        [DataMember]
        public int Id_ucionice { get; set; }
        [DataMember]
        public int broj_ucenika { get; set; }
        [DataMember]
        public string naziv { get; set; }
    }
}
