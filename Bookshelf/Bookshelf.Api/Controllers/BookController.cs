using System.Threading.Tasks;
using Bookshelf.Api.Mappers1;
using Bookshelf.Api.Validation;
using Bookshelf.Data.Sql;
using Bookshelf.Domain.Book;
using Bookshelf.IServices.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book = Bookshelf.Data.SQL.DAO.Book;

namespace Bookshelf.Api.Controllers
{
  [ApiVersion("2.0")]
  [Route("api/v{version:apiVersion}/book")]

  public class BookController : Controller
  {
    private readonly BookshelfDbContext _context;
    private readonly IBookService _bookService;
    /// <inheritdoc />
    public BookController(BookshelfDbContext context, IBookService bookService)
    {
      _context = context;
      _bookService = bookService;
    }

    [HttpGet(template: "GetAllBooks")]
    public List<Book> GetAllBooks()
    {
      return _context.Book.ToList();
    }

    [HttpGet("{bookId:min(1)}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookByBookId(int bookId)
    {
      var book = await _bookService.GetBookByBookId(bookId);
      if (book != null)
      {
        return Ok(BookToBookViewModelMapper.BookToBookViewModel(book));
      }
      return NotFound();
    }

    [HttpGet("title/{title}", Name = "GetBookByTitle")]
    public async Task<IActionResult> GetBookByTitle(string title)
    {
      var book = await _bookService.GetBookByTitle(title);
      if (book != null)
      {
        return Ok(BookToBookViewModelMapper.BookToBookViewModel(book));
      }
      return NotFound();
    }

    [ValidateModel]
    public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateBook createBook)
    {
      var book = await _bookService.CreateBook(createBook);

      return Created(book.BookId.ToString(), BookToBookViewModelMapper.BookToBookViewModel(book));
    }


    [ValidateModel]
    [HttpPatch("edit/{bookId:min(1)}", Name = "EditBook")]
    //        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
    public async Task<IActionResult> EditBook([FromBody] IServices.Requests.EditBook editBook, int bookId)
    {
      await _bookService.EditBook(editBook, bookId);

      return NoContent();
    }

    //dodaje usuwanie
    /*[HttpDelete("delete/{bookId:min(1)}", Name = "DeleteBook")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
        // pobranie ksiazki
        var book = await _context.Book.FirstOrDefaultAsync(x => x.BookId == bookId);
        if (book == null)
        {
            return NotFound();
        }

        var bookpref =  _context.BookPreference.Where(x => x.BookId == bookId);
        _context.BookPreference.RemoveRange(bookpref);

        var review =  _context.Review.Where(x => x.BookId == bookId);
        _context.Review.RemoveRange(review);


        // to nie dziala
        _context.Book.Remove(book);
        //_context.Entry(book).State = EntityState.Deleted;

        // iservices deletebook
        // services deletebook

        // to sie sypie
        //await _context.SaveChangesAsync();
        //_context.SaveChanges();
        return NoContent();
    }*/
    /*[HttpDelete("{bookId:min(1)}", Name = "DeleteBook")]
    [ValidateModel]
    public async Task<IActionResult> DeleteBook(int bookId)
    {

        await _bookService.DeleteBook(bookId);
        return NoContent();
    }*/
    [HttpDelete("delete/{bookId:min(1)}", Name = "DeleteBook")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
      var book = await _context.Book.FirstOrDefaultAsync(x => x.BookId == bookId);

      var bookpreference = _context.BookPreference.Where(x => x.BookId == bookId);
      _context.BookPreference.RemoveRange(bookpreference);
      await _context.SaveChangesAsync();

      //var review =  _context.Review.Where(x => x.BookId == bookId);
      var review = _context.Review.Where(x => x.BookId == bookId);
      _context.Review.RemoveRange(review);
      await _context.SaveChangesAsync();


      _context.Book.Remove(book);

      _context.SaveChanges();
      return NoContent();
    }


  }
}