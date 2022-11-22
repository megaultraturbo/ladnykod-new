using System.Threading.Tasks;
using Bookshelf.Data.Sql.Book;
using Bookshelf.IData.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Bookshelf.Data.Sql.Tests.Book
{
    public class BookRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private BookshelfDbContext _context;
        private IBookRepository _bookRepository;

        public BookRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookshelfDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=;port=3306;database=bookshelf_db;");
            _context = new BookshelfDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _bookRepository = new BookRepository(_context);
        }

        [Fact]
        public async Task AddBook_Returns_Correct_Response()
        {
            var book = new Domain.Book.Book(1, "przygoda", 42);

            var bookId = await _bookRepository.AddBook(book);

            var createdBook = await _context.Book.FirstOrDefaultAsync(x => x.BookId == bookId);
            Assert.NotNull(createdBook);

            _context.Book.Remove(createdBook);
            await _context.SaveChangesAsync();
        }

    }
}