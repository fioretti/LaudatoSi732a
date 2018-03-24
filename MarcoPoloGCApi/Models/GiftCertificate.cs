using System;
using System.Collections.Generic;

namespace MarcoPoloGCApi.Models
{
    public partial class GiftCertificate
    {
        public GiftCertificate()
        {
            Gcpurchase = new HashSet<Gcpurchase>();
            Gcredemption = new HashSet<Gcredemption>();
            GcservicesType = new HashSet<GcservicesType>();
        }

        public int Id { get; set; }
        public int? GctypeId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public string DtipermitNo { get; set; }
        public DateTime? ValidityPeriod { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Gctype Gctype { get; set; }
        public ICollection<Gcpurchase> Gcpurchase { get; set; }
        public ICollection<Gcredemption> Gcredemption { get; set; }
        public ICollection<GcservicesType> GcservicesType { get; set; }
    }
}
