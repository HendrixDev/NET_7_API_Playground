using NET_7_API_Playground.Data;
using NET_7_API_Playground.Entities.Models;

namespace NET_7_API_Playground.Endpoints
{
    public static class BooksEndpoints
    {
        public static void MapBookEndpoints(this WebApplication application)
        {
            application.MapGet("/books", (IBookRepository bookRepository) =>
            {
                return Results.Ok(bookRepository.GetBooks());
            }).WithName("GetBooks").WithOpenApi();

            application.MapGet("/books/{id}", (int id, IBookRepository bookRepository) =>
            {
                var book = bookRepository.GetBook(id);
                return Results.Ok(book);
            }).WithName("GetBookById").WithOpenApi();

            application.MapPost("/books/", (Book book, IBookRepository bookRepository) =>
            {
                Results.Ok(bookRepository.CreateBookReturnsId(book));
            }).WithName("CreateBook").WithOpenApi();
        }
    }
}
