using System;
using System.Threading.Tasks;
using Bookshelf.Domain.DomainExceptions;
using Bookshelf.IData.Book;
using Bookshelf.IServices.Requests;
using Bookshelf.IServices.Book;
using Bookshelf.Services.Book;
using Moq;
using Xunit;

namespace Bookshelf.Services.Tests.Book
{
    public class BookServiceTest
    {
        private readonly IBookService _bookService;
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        
        public BookServiceTest()
        {
            //Arrange
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateBook_Returns_Correct_Response()
        {
            var book = new CreateBook
            {
                AuthorId = 1,
                Title = "ksiazka stulecia",
                PagesNumber = 60
            };
            
            int expectedResult = 0;
            _bookRepositoryMock.Setup(x => x.AddBook
                (new Domain.Book.Book
                (book.AuthorId, 
                    book.Title, 
                    book.PagesNumber)))
                .Returns(Task.FromResult(expectedResult));
            
            //Act
            var result = await _bookService.CreateBook(book);

            //Assert
            Assert.IsType<Domain.Book.Book>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.BookId);
        }

    }
}