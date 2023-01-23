using FieryRestaurant.DTO;
using FieryRestaurant.DTO.Filter;
using FieryRestaurant.DTO.Wrapper;
using FieryRestaurant.Entities;
using FieryRestaurant.Repository.Logger;
using FieryRestaurant.Service.Service.Interface;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using NLog.Fluent;
using System.Diagnostics;

namespace FieryRestaurant.API.Controllers
{

    [EnableQuery]
    [ApiController]
    [Route("api/[controller]")]
    public class FieryController : ControllerBase
    {
        private readonly IFieryService service;
        private readonly ILoggerManager logger;

        public FieryController(IFieryService service,ILoggerManager logger)
        {
            this.service = service;
            this.logger = logger;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            try
            {
                logger.LogInfo("Get all the Supplier");
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                List<SupplierDTO> supplierDTOs = service.GetSuppliers();
                if (supplierDTOs == null)
                {
                    return NotFound();
                }
                stopwatch.Stop();
                var OutputTime = stopwatch.Elapsed;
                return Ok(supplierDTOs);
            }
            catch (Exception ex)
            {
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
                logger.LogDebug("Get by Id Method Executing.....");
                var supplierDTO = service.GetSupplier(id);
                if (supplierDTO == null)
                {
                    logger.LogWarning($"Genre with Id{supplierDTO.SupplierID} not fount");
                    return NotFound();
                }
                return Ok(supplierDTO);
            }catch(Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(SupplierDTO supplierDTO)
        {
            try
            {
                 SupplierDTO resultDTO = service.AddSupplier(supplierDTO);
                return Created($"api/controller/Supplier{resultDTO.SupplierID}", resultDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/pagination")]
        public IActionResult Get([FromQuery]PaginationFilter filter)
        {
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pageDate = service.GetSuppliers().Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToList();
                var totalRecord = service.GetSuppliers().Count();
                return Ok(new PageResponse<List<SupplierDTO>>(pageDate,validFilter.PageNumber,validFilter.PageSize));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
