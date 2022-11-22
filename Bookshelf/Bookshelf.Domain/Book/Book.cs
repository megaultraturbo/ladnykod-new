using System;
using Bookshelf.Domain.DomainExceptions;

namespace Bookshelf.Domain.Book
{
    public class Book
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int PagesNumber { get; set; }

        public Book(int bookId, int authorId, string title, int pagesNumber)
        {
            BookId = bookId;
            AuthorId = authorId;
            Title = title;
            PagesNumber = pagesNumber;
        }
        public Book(int authorId, string title, int pagesNumber)
        {
            AuthorId = authorId;
            Title = title;
            PagesNumber = pagesNumber;
        }

        public void EditBook(int bookId, int authorId, string title, int pagesNumber)
        {
            BookId = bookId;
            AuthorId = authorId;
            Title = title;
            PagesNumber = pagesNumber;
        }
        
        public void EditBook(int createBookAuthorId, string title, int pagesNumber)
        {
            Title = title;
            PagesNumber = pagesNumber;
        }
    }
}