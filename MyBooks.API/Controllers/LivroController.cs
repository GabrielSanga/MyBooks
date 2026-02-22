using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.Queries.BuscarLivros;

namespace MyBooks.API.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LivroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLivros(string titulo, string autor = "", string genero = "")
        {
            var result = await _mediator.Send(new BuscarLivrosQuery(titulo, autor, genero));

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
