using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.Commands.AdicionarLivro;
using MyBooks.Application.Commands.AlteraLivroLido;
using MyBooks.Application.Commands.AlterarLivroCancelado;
using MyBooks.Application.Commands.AlterarLivroLendo;
using MyBooks.Application.Commands.AlterarLivroQueroLer;
using MyBooks.Application.Queries.BuscarBiblioteca;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        [HttpGet]
        public async Task<IActionResult> Buscar(BuscarBibliotecaQuery bibliotecaQuery)
        {
            var result = await _mediator.Send(bibliotecaQuery);

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{idBiblioteca}/queroler")]
        public async Task<IActionResult> QueroLer(int idBiblioteca)
        {
            var result = await _mediator.Send(new AlterarLivroQueroLerCommand(idBiblioteca));

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{idBiblioteca}/lendo")]
        public async Task<IActionResult> Lendo(int idBiblioteca)
        {
            var result = await _mediator.Send(new AlterarLivroLendoCommand(idBiblioteca));

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{idBiblioteca}/lido")]
        public async Task<IActionResult> Lido(int idBiblioteca)
        {
            var result = await _mediator.Send(new AlterarLivroLidoCommand(idBiblioteca));

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{idBiblioteca}/cancelado")]
        public async Task<IActionResult> Cancelado(int idBiblioteca)
        {
            var result = await _mediator.Send(new AlteraLivroCanceladoCommand(idBiblioteca));

            if (!result.Sucesso)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
