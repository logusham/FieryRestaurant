using FieryRestaurant.DTO;
using FieryRestaurant.Service.Service.Interface;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieryRestaurant.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FieryController : ControllerBase
    {
        public IFieryService service;
        public FieryController(IFieryService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("{id:guid}")]
        [EnableQuery]
      public IActionResult GetSupplier(Guid id)
        {
            try
            {
                var supplier = service.GetSupplier(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddSupplier(SupplierDTO supplier)
        {
            try
            {
                bool result = service.AddSupplier(supplier);
                if (result)
                {
                    return Ok(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("{id:guid}")]
        [EnableQuery]
       public IActionResult UpdateSupplier(Guid id,SupplierDTO Supplier)
        {
            try
            {
                var supplier = service.UpdateSupplier(id, Supplier);
                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteSupplier(Guid id)
        {
            try
            {
                bool result = service.DeleteSupplier(id);
                if (result)
                {
                    return Ok(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult GetSuppliers()
        {
            try
            {
                var suppliers = service.GetSuppliers();
                if (suppliers == null)
                {
                    return NotFound();
                }
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
