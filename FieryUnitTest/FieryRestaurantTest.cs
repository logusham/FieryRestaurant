using FieryRestaurant.API.Controllers;
using FieryRestaurant.DTO;
using FieryRestaurant.Entities;
using FieryRestaurant.Repository.DataAccess;
using FieryRestaurant.Service.Service.Implimentation;
using FieryRestaurant.Service.Service.Interface;
using Moq;

namespace FieryUnitTest
{
    [TestClass]
    public class FieryRestaurantTest
    {
        public Mock<IFieryService> service;
        public FieryRestaurantTest()
        {
            service = new Mock<IFieryService>();
        }

        [TestMethod]
        public void PostSupplier()
        {
            SupplierDTO supplierDTO = new SupplierDTO()
            {
                SupplierID = Guid.NewGuid(),
                SupplierName = "Tarun",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = "Logu",
                IsActive = true,
                Business = new BusinessDTO()
                {
                    BusinessName = "DotNet",
                    LicenseDate = new DateTime(2022,04,05),
                    LicenseNo=959899345,

                },
                Address = new AddressDTO()
                {
                    StreetAddress = "106",
                    City = "Virginia Beach",
                    State = "VA",
                    Contry = "US",
                    ZipCode =234560000,
                    Latitude = "39.681660",
                    Longitude = "-75.753609"

                },

            };
            service = new Mock<IFieryService>();
         //   FieryController fieryController = new FieryController(service.Object);
            //SupplierDTO resultDTO = (SupplierDTO)
              //  fieryController.Post(supplierDTO);
            //Assert.AreEqual(supplierDTO, resultDTO);
        }
    }
}