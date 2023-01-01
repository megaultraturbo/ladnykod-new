using System.Threading.Tasks;
using Bookshelf.IData.Book;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Bookshelf.Data.SQL.DAO;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.Data.Sql.Book
{
  public class BookRepository : IBookRepository
  {
    private readonly BookshelfDbContext _context;

    public BookRepository(BookshelfDbContext context)
    {
      _context = context;
    }

    public async Task<int> AddBook(Domain.Book.Book book)
    {
      var bookDAO = new SQL.DAO.Book
      {
        BookId = book.BookId,
        AuthorId = book.AuthorId,
        Title = book.Title,
        PagesNumber = book.PagesNumber
      };
      await _context.AddAsync(bookDAO);
      await _context.SaveChangesAsync();
      return bookDAO.BookId;
    }

    public async Task<Domain.Book.Book> GetBook(int bookId)
    {
      var book = await _context.Book.FirstOrDefaultAsync(x => x.BookId == bookId);
      return new Domain.Book.Book(book.BookId,
          book.AuthorId,
          book.Title,
          book.PagesNumber);
    }

    public async Task<Domain.Book.Book> GetBook(string title)
    {
      var book = await _context.Book.FirstOrDefaultAsync(x => x.Title == title);
      return new Domain.Book.Book(book.BookId,
          book.AuthorId,
          book.Title,
          book.PagesNumber);
    }

    public async Task EditBook(Domain.Book.Book book)
    {
      var editBook = await _context.Book.FirstOrDefaultAsync(x => x.BookId == book.BookId);
      editBook.AuthorId = book.AuthorId;
      editBook.Title = book.Title;
      editBook.PagesNumber = book.PagesNumber;
      await _context.SaveChangesAsync();
    }

    ///nowe
    public async Task DeleteBook(Domain.Book.Book book)
    {
      var loop = true;
      do
      {
        var DeleteBookPreference = await _context.BookPreference.FirstOrDefaultAsync(n => n.BookId == book.BookId);
        if (DeleteBookPreference != null)
        {
          _context.BookPreference.Remove(DeleteBookPreference);
        }
        else
        {
          loop = false;
        }

        await _context.SaveChangesAsync();
      } while (loop);

      var DeleteReview = await _context.Review.FirstOrDefaultAsync(n => n.BookId == book.BookId);
      if (DeleteReview != null)
      {
        _context.Review.Remove((DeleteReview));
      }

      var DeleteBook = await _context.Book.FirstOrDefaultAsync(n => n.BookId == book.BookId);
      if (DeleteBook != null)
      {
        _context.Book.Remove(DeleteBook);
      }

      await _context.SaveChangesAsync();

    }
  }

}