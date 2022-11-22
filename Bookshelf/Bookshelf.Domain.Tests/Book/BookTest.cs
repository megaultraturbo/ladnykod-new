using System;
using Bookshelf.Domain.DomainExceptions;
using Xunit;

namespace Bookshelf.Domain.Tests.Book
{
    public class BookTest
    {
        public BookTest()
        {
            //Arrange
            //Act
            //Assert
        }
        
        
        [Fact]
        public void EditBook_Returns_Invalid_Response()
        {
            var book = new Domain.Book.Book(1, "tytuluwua", 33);

            Assert.Equal(1, book.AuthorId);
            Assert.NotEqual("title", book.Title);
            Assert.Equal(33, book.PagesNumber);
        }
        
        [Fact]
        public void EditBook_Returns_Valid_Response()
        {
            var book = new Domain.Book.Book(1, "tytuluwua", 33);

            Assert.Equal(1, book.AuthorId);
            Assert.Equal("tytuluwua", book.Title);
            Assert.Equal(33, book.PagesNumber);
        }

    }
}