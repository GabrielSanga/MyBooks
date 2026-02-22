using Microsoft.Extensions.Options;
using MyBooks.Core.Entities;
using MyBooks.Core.ReadModels;
using MyBooks.Core.Services;
using MyBooks.Infrastructure.ExternalService.GoogleBooksAPI.Models;
using System.Net.Http.Json;

namespace MyBooks.Infrastructure.ExternalService.GoogleBooksAPI
{
    public class GoogleBookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly GoogleBooksOptions _options;

        public GoogleBookService(HttpClient client, IOptions<GoogleBooksOptions> options) {
            _httpClient = client;
            _options = options.Value;
        }

        public async Task<List<LivroReadModel>> BuscarLivros(string filtro)
        {
            var livros = new List<LivroReadModel>();

            var response = await _httpClient.GetFromJsonAsync<LivroExternalResponse>($"books/v1/volumes?q={filtro}&printType=books&key={_options.ApiKey}");

            if (response is null || response.Items is null || response.Items.Count == 0) {
                return livros;
            }

            foreach (var item in response.Items)
            {
                var livro = new LivroReadModel();

                livro.IdExterno = item.Id;
                livro.Titulo = item.Volume.Titulo;
                livro.Descricao = item.Volume.Descricao;
                livro.ISBN = item.Volume.ISBNs?.FirstOrDefault()?.ISBN ?? "";
                livro.Autor = string.Join(", ", item.Volume.Autores ?? new List<string>());
                livro.Editora = item.Volume.Editora;
                livro.Genero = string.Join(", ", item.Volume.Genero ?? new List<string>());
                livro.URLCapa = item.Volume.LinksImagem?.UrlCapa ?? "";
                if (DateTime.TryParse(item.Volume.DataPublicacao, out DateTime data))
                {
                    livro.AnoPublicacao = data;
                }

                livros.Add(livro);
            }

            return livros;
        }
    }
}
