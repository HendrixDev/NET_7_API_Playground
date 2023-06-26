using NET_7_API_Playground.Models;

namespace NET_7_API_Playground.Data
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
    }
}
