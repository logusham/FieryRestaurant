using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Entities
{
    public class Business
    {
        [Key]
        public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        public int LicenseNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime LicenseDate { get; set; }
    }
}
