using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.Commands.AdicionarLivro;

namespace MyBooks.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/biblioteca")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BibliotecaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(AdicionarLivroCommand adicionarLivroCommand)
        {
            var result = await _mediator.Send(adicionarLivroCommand);

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
