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
    public class SoilHistoricController : ControllerBase
    {
        private ISoilHistoricService _service;
        public SoilHistoricController(ISoilHistoricService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<SoilHistoricGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SoilHistoricEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(SoilHistoricInsertDTO soilHistoric)
        {
            return Ok(await _service.Post(soilHistoric));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(SoilHistoricEntity soilHistoric)
        {
            return Ok(await _service.Update(soilHistoric));
        }
    }
}
