using AutoMapper;
using FieryRestaurant.Business.Mapping.Interface;
using FieryRestaurant.DTO;
using FieryRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Business.Mapping.Implimentation
{
    public class FieryMapping : IFieryMapping
    {
        private readonly IMapper mapper;

        public FieryMapping(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Supplier ChangeSupplierDTOToSupplier(SupplierDTO supplierDTO)
        {
            Supplier supplier = mapper.Map<SupplierDTO, Supplier>(supplierDTO);
            return supplier;
        }

        public List<SupplierDTO> ChangeSupplierToSupplierDTO(List<Supplier> suppliers)
        {
            List<SupplierDTO> supplierDTOs = mapper.Map<List<Supplier>, List<SupplierDTO>>(suppliers);
            return supplierDTOs;
        }

    }
}
