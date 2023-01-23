using AutoMapper;
using FieryRestaurant.DTO;
using FieryRestaurant.Entities;

namespace FieryRestaurant.Service
{
    public class FieryMapperProfile : Profile
    {
        public FieryMapperProfile()
        {
            CreateMap<SupplierDTO, Supplier>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<BusinessDTO, Entities.Business>().ReverseMap();
        }
    }
}
 