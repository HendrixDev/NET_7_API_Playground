using NET_7_API_Playground.Data;

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
        }
    }
}
