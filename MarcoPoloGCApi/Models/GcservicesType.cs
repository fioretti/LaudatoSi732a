using System;
using System.Collections.Generic;

namespace MarcoPoloGCApi.Models
{
    public partial class GcservicesType
    {
        public int Id { get; set; }
        public int? GiftCertificateId { get; set; }
        public int? ServicesTypeId { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public GiftCertificate GiftCertificate { get; set; }
        public ServicesType ServicesType { get; set; }
    }
}
