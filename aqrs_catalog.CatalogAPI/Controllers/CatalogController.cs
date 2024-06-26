using aqrs_catalog.CatalogAPI.DTOs;
using aqrs_catalog.CatalogAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aqrs_catalog.CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> Get()
        {
            try
            {
                var catalogs = await _service.GetAllAsync();
                return Ok(catalogs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> Get(Guid id)
        {
            try
            {
                var catalog = await _service.GetByIdAsync(id);              

                return Ok(catalog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        [HttpPost]   
        public async Task<ActionResult<CatalogDTO>> Create(CatalogInsDTO catalogInsDTO)
        {
            try
            {
                return await _service.CreateAsync(catalogInsDTO);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<CatalogDTO>> Update(CatalogPutDTO catalogPutDTO)
        {
            try
            {
                return await _service.UpdateAsync(catalogPutDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CatalogDTO>> Delete(Guid id)
        {
            try
            {
                var catalog = await _service.DeleteAsync(id);
                return Ok(catalog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
