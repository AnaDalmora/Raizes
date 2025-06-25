using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Response;
using ApiRaizes.Services;
using MassTransit.Clients;
using Microsoft.AspNetCore.Mvc;

namespace ApiRaizes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RawMaterialStockController : ControllerBase
    {
        private IRawMaterialStockService _service;
        public RawMaterialStockController(IRawMaterialStockService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<RawMaterialStockGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RawMaterialStockEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(RawMaterialStockInsertDTO rawMaterialStock)
        {
            return Ok(await _service.Post(rawMaterialStock));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(RawMaterialStockEntity rawMaterialStock)
        {
            return Ok(await _service.Update(rawMaterialStock));
        }
    }
}
