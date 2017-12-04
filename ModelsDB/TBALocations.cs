using System.Runtime.Serialization;

namespace CompanyDbWebAPI.ModelsDB
{
    [DataContract(IsReference = true)]
    public class TBALocation
    {
        //[Key]
        [DataMember]
        public string CODE { get; set; }
        [DataMember]
        public string NAME { get; set; }
        [DataMember]
        public string Csl_Assigned_INITIAL { get; set; }
        [DataMember]
        public virtual ContractConsultant Csl_Assigned { get; set; }

    }
}