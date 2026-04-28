using Microsoft.AspNetCore.Mvc;
using SecureSales.Application.DTOs;
using SecureSales.Application.Interfaces;

namespace SecureSales.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(ClienteDto dto)
        {
            var id = _service.Criar(dto);
            return Ok(new { Id = id });
        }
    }
}
