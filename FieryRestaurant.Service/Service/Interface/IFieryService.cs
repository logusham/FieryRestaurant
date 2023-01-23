using FieryRestaurant.DTO;
using FieryRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Service.Service.Interface
{
    public interface IFieryService
    {
        public SupplierDTO GetSupplier(Guid id);
        public SupplierDTO AddSupplier(SupplierDTO supplier);
        public List<SupplierDTO> GetSuppliers();
    }
}
