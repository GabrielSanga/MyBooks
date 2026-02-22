using System.Text.Json.Serialization;

namespace MyBooks.Infrastructure.ExternalService.GoogleBooksAPI.Models
{
    internal record LivroExternalResponse
    (
        [property: JsonPropertyName("kind")] string Tipo,
        [property: JsonPropertyName("items")] List<LivroItemExternalResponse>? Items
    );

    internal record LivroItemExternalResponse
    (
       [property: JsonPropertyName("id")] string Id,
       [property: JsonPropertyName("volumeInfo")] LivroVolumeInfoExternalReponse Volume
    );

    internal record LivroVolumeInfoExternalReponse
    (
       [property: JsonPropertyName("title")] string Titulo,
       [property: JsonPropertyName("authors")] List<string> Autores,
       [property: JsonPropertyName("description")] string Descricao,
       [property: JsonPropertyName("publisher")] string Editora,
       [property: JsonPropertyName("categories")] List<string> Genero,
       [property: JsonPropertyName("publishedDate")] string DataPublicacao,
       [property: JsonPropertyName("industryIdentifiers")] List<LivroIndustryIdentifiersExternalReponse> ISBNs,
       [property: JsonPropertyName("imageLinks")] LivroImageLinksExternalReponse LinksImagem
    );

    internal record LivroImageLinksExternalReponse
    (
        [property: JsonPropertyName("smallThumbnail")] string UrlCapa
    );

    internal record LivroIndustryIdentifiersExternalReponse
    (
       [property: JsonPropertyName("identifier")] string ISBN
    );
}
