using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CompanyDbWebAPI.ModelsDB
{
    [DataContract(IsReference = true)]
    public class ContractConsultant
    {

        public ContractConsultant()
        {
            LocationsAssigned = new List<TBALocation>();
        }

        //[Key]
        [DataMember]
        public string INITIALS { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public virtual ICollection<TBALocation> LocationsAssigned { get; set; }
    }
}