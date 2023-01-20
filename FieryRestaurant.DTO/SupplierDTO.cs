using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.DTO
{
    public class SupplierDTO
    {
        public Guid SupplierID { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public BusinessDTO Business { get; set; }

        public AddressDTO Address { get; set; }
    }
}
