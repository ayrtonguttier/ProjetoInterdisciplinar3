using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjInter3.Models;
using ProjInter3.Servicos;

namespace ProjInter3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        [HttpPost]
        public IActionResult CadastrarCliente([FromServices] ClienteRepository repository, [FromBody] ClienteModel cliente)
        {
            repository.Add(cliente);
            return CreatedAtAction(nameof(ConsultarCliente), cliente);
        }

        [HttpGet("{idCliente:int}")]
        public IActionResult ConsultarCliente([FromServices] ClienteRepository repository, int idCliente)
        {
            ClienteModel? cliente = repository.GetById(idCliente);

            if (cliente is null)
                return NotFound();

            return Ok(cliente);
        }



    }
}
