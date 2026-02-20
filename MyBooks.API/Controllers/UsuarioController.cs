using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.Commands.CommandsUsuario;

namespace MyBooks.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator) { 
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(InserirUsuarioCommand usuarioCommand)
        {
            var result = await _mediator.Send(usuarioCommand);

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
