using Microsoft.AspNetCore.Http.HttpResults;
using NET_7_API_Playground.Data;
using NET_7_API_Playground.Endpoints;
using NET_7_API_Playground.Entities.Models;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace NET_7_API_Playground.Tests
{
    public class BookEndpointTests
    {
        private readonly IBookRepository _bookRepository = Substitute.For<IBookRepository>();

        [Fact]
        public void GetBookById_Returns_Book()
        { 
            //arrange
            int id = 1;
            Book book = new(){Id = id, Title = "Test Title", Author = "Test Author"};
            _bookRepository.GetBook(Arg.Is(id)).Returns(book);

            //act
            var result = BooksEndpoints.GetBookById(_bookRepository, id);

            //assert
            Assert.IsType<Ok<Book>>(result);

            var okResult = (Ok<Book>)result;

            Assert.NotNull(okResult.Value);
            Assert.Equal(1, okResult.Value.Id);
        }

        [Fact]
        public void GetBookById_Returns_NotFound()
        {
            //arrange
            _bookRepository.GetBook(Arg.Is(1)).ReturnsNull();

            //act
            var result = BooksEndpoints.GetBookById(_bookRepository, 1);

            //assert
            Assert.IsType<NotFound>(result);

            var notFoundResult = (NotFound)result;

            Assert.NotNull(notFoundResult);
        }
    }
}
