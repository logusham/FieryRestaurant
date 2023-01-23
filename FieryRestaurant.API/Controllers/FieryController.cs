using FieryRestaurant.DTO;
using FieryRestaurant.Entities;
using FieryRestaurant.Service.Service.Interface;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using System.Diagnostics;

namespace FieryRestaurant.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class FieryController : ControllerBase
    {
        private readonly IFieryService service;
        private readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public FieryController(IFieryService service)
        {
            this.service = service;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                List<SupplierDTO> supplierDTOs = service.GetSuppliers();
                if (supplierDTOs == null)
                {
                    return NotFound();
                }
                stopwatch.Stop();
                var OutputTime=stopwatch.Elapsed;
                return Ok(supplierDTOs);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id:guid}")]
        [EnableQuery]
      public IActionResult Get([FromRoute] Guid id)
        {
            try
            {
                var supplierDTO = service.GetSupplier(id);
                if (supplierDTO == null)
                {
                    return NotFound();
                }
                return Ok(supplierDTO);
            }catch(Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(SupplierDTO supplierDTO)
        {
            try
            {
                 SupplierDTO resultDTO = service.AddSupplier(supplierDTO);
                return Ok(resultDTO);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
       
    }
}
