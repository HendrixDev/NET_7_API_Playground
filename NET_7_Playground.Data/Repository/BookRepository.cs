using Microsoft.Extensions.Logging;
using NET_7_API_Playground.Entities.Models;

namespace NET_7_API_Playground.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> _logger;
        private readonly DataContext _dataContext;

        public BookRepository(ILogger<BookRepository> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public List<Book> GetBooks() 
        {
            _logger.LogInformation("Getting All Books");
            return _dataContext.Books.ToList();
        }

        public Book GetBook(int id)
        {
            _logger.LogInformation($"Getting Book with Id: {id}");
            return _dataContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public int CreateBookReturnsId(Book book)
        {
            _logger.LogInformation($"Creating new book: {book.Title}");
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();
            return book.Id;
        }
    }


}

