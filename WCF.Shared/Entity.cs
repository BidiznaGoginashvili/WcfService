using System.Runtime.Serialization;

namespace WCF.Shared
{
    [DataContract]
    public class Entity
    {
        [DataMember]
        public int Id { get; set; }
    }
}
