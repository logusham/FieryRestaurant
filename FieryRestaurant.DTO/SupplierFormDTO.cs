using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.DTO
{
    public class SupplierFormDTO
    {
        public string SupplierName { get; set; }
        public bool IsActive { get; set; }
        public string BusinessName { get; set; }
        public int LicenseNo { get; set; }
        public DateTime LicenseDate { get; set; }
        public int AddressID { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Contry { get; set; }
        public int ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
