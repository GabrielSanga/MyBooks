using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.Commands.InserirUsuario;
using MyBooks.Application.Commands.LogarUsuario;

namespace MyBooks.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Logar(LogarUsuarioCommand usuarioCommand)
        {
            var result = await _mediator.Send(usuarioCommand);

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [AllowAnonymous]
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
