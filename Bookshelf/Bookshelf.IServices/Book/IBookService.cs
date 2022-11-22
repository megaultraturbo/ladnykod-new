using System.Threading.Tasks;
using Bookshelf.IServices.Requests;

namespace Bookshelf.IServices.Book
{
    public interface IBookService
    {
        Task<Bookshelf.Domain.Book.Book> GetBookByBookId(int bookId);
        Task<Bookshelf.Domain.Book.Book> GetBookByTitle(string title);
        Task<Bookshelf.Domain.Book.Book> CreateBook(CreateBook createBook);
        Task EditBook(EditBook createBook, int bookId);
        // nowe
        Task DeleteBook(int bookId);
    }
}