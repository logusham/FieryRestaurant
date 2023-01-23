using FieryRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Repository.Repository.Interface
{
    public interface IFieryRepository
    {
        public bool AddSupplierInDb(Supplier supplier);
        public List<Supplier> GetSuppliersInDb();
    }
}
