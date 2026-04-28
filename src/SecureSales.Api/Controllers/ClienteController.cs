using Microsoft.AspNetCore.Mvc;
using SecureSales.Application.DTOs;
using SecureSales.Application.Interfaces;
using System.Threading.Tasks;

namespace SecureSales.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _service.Listar();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto dto)
        {
            return Ok(new { Id = 2026 });
        }
    }
}
