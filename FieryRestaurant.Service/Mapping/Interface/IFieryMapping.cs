using FieryRestaurant.DTO;
using FieryRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Business.Mapping.Interface
{
    public interface IFieryMapping
    {
        public List<SupplierDTO> ChangeSupplierToSupplierDTO(List<Supplier> suppliers);
        public Supplier ChangeSupplierDTOToSupplier(SupplierDTO supplierDTO);
    }
}
