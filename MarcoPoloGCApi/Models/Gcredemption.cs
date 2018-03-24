using System;
using System.Collections.Generic;

namespace MarcoPoloGCApi.Models
{
    public partial class Gcredemption
    {
        public int Id { get; set; }
        public int? GiftCertificateId { get; set; }
        public DateTime? RedemptionDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedDate { get; set; }

        public GiftCertificate GiftCertificate { get; set; }
    }
}
