using AutoMapper;
using FieryRestaurant.Business.Mapping.Implimentation;
using FieryRestaurant.Business.Mapping.Interface;
using FieryRestaurant.DTO;
using FieryRestaurant.Entities;
using FieryRestaurant.Repository.Repository.Implimentation;
using FieryRestaurant.Repository.Repository.Interface;
using FieryRestaurant.Service.Service.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryRestaurant.Service.Service.Implimentation
{
    public class FieryService : IFieryService
    {
        private readonly IFieryRepository repository;
        private readonly IFieryMapping mapping;
        private readonly IMemoryCache memoryCache;

        public FieryService(IFieryRepository repository, IFieryMapping mapping, IMemoryCache memoryCache)
        {
            this.repository = repository;
            this.mapping = mapping;
            this.memoryCache = memoryCache;
        }
        public SupplierDTO AddSupplier(SupplierDTO supplierDTO)
        {
            bool result = false;
            var now = DateTime.Today;
            int Licenseyear = (now.Year - supplierDTO.Business.LicenseDate.Year - 1) +
                    (((now.Month > supplierDTO.Business.LicenseDate.Month) ||
                    ((now.Month == supplierDTO.Business.LicenseDate.Month) && (now.Day >= supplierDTO.Business.LicenseDate.Day))) ? 1 : 0);
            if (Licenseyear >= 0)
            {
                if ((Licenseyear <= 10))
                {
                    supplierDTO.SupplierID = Guid.NewGuid();
                    supplierDTO.CreatedDate = DateTime.Now;
                    supplierDTO.LastModifiedDate = DateTime.Now;
                    Supplier supplier = mapping.ChangeSupplierDTOToSupplier(supplierDTO);
                    result = repository.AddSupplierInDb(supplier);
                    memoryCache.Remove("Suppliers");
                }
                else
                {
                    throw new Exception("License is Expired");
                }
            }
            else
            {
                throw new Exception("Enter Valid Date");
            }
            if (result)
            {
                return supplierDTO;
            }
            throw new NotImplementedException();
        }
        public SupplierDTO GetSupplier(Guid id)
        {
            SupplierDTO supplierDTO = GetSuppliers().Where(x => x.SupplierID==id).First();
            return supplierDTO;
        }

        public List<SupplierDTO> GetSuppliers()
        {
            List<Supplier> suppliers;
            if (!memoryCache.TryGetValue("Suppliers", out suppliers))
            {
                memoryCache.Set("Suppliers", repository.GetSuppliersInDb());
            }
            suppliers = memoryCache.Get("Suppliers") as List<Supplier>;
            List<SupplierDTO> supplierDTOs = mapping.ChangeSupplierToSupplierDTO(suppliers);
            return supplierDTOs;
        }
    }
}
