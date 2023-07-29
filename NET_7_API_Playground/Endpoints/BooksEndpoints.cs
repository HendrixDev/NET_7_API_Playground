using NET_7_API_Playground.Data;
using NET_7_API_Playground.Entities.Models;

namespace NET_7_API_Playground.Endpoints
{
    public static class BooksEndpoints
    {
        public static void MapBookEndpoints(this WebApplication application)
        {
            application.MapGet("/books", GetBooks).WithName("GetBooks").WithOpenApi();
            application.MapGet("/books/{id}", GetBookById).WithName("GetBooksById").WithOpenApi();
            application.MapPost("/books", CreateBook).WithName("CreateBook").WithOpenApi();
        }

        public static void AddBookServices(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
        }

        internal static List<Book> GetBooks(IBookRepository bookRepository)
        {
            return bookRepository.GetBooks();
        }

        internal static IResult GetBookById(IBookRepository bookRepository, int id)
        { 
            var book = bookRepository.GetBook(id);
            return book != null ? Results.Ok(book) : Results.NotFound();
        }

        internal static IResult CreateBook(IBookRepository bookRepository, Book book)
        { 
            int id = bookRepository.CreateBookReturnsId(book);
            return id != 0 ? Results.Ok(id) : Results.NotFound();
        }
    }
}
