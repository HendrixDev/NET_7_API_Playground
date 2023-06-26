using NET_7_API_Playground.Models;

namespace NET_7_API_Playground.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(ILogger<BookRepository> logger)
        {
            _logger = logger;
            _books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Author = "Robert Martin"
                },
                new Book
                {
                    Id = 2,
                    Title = "Clean Architecture",
                    Author = "Robert Martin"
                },
                new Book
                {
                    Id = 3,
                    Title = "Refactoring",
                    Author = "Martin Fowler"
                }
            };
        }

        public List<Book> GetBooks() 
        {
            _logger.LogInformation("Getting All Books");
            return _books;
        }

        public Book GetBook(int id)
        {
            _logger.LogInformation($"Getting Book with Id: {id}");
            return _books.Find(x => x.Id == id);
        }
    }


}

