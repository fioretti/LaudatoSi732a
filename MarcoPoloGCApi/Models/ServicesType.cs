using System;
using System.Collections.Generic;

namespace MarcoPoloGCApi.Models
{
    public partial class ServicesType
    {
        public ServicesType()
        {
            GcservicesType = new HashSet<GcservicesType>();
        }

        public int Id { get; set; }
        public string ServicesType1 { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<GcservicesType> GcservicesType { get; set; }
    }
}
