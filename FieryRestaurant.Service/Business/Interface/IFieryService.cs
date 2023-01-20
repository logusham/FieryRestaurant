using FieryRestaurant.DTO;
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
        public bool AddSupplier(SupplierDTO supplier);
        public SupplierDTO UpdateSupplier(Guid id,SupplierDTO supplier);
        public bool DeleteSupplier(Guid id);
        public List<SupplierDTO> GetSuppliers();
    }
}
