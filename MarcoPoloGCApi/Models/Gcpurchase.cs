using System;
using System.Collections.Generic;

namespace MarcoPoloGCApi.Models
{
    public partial class Gcpurchase
    {
        public int Id { get; set; }
        public int? GiftCertificateId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public GiftCertificate GiftCertificate { get; set; }
    }
}
