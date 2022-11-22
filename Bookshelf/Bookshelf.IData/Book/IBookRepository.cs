using System.Threading.Tasks;

namespace Bookshelf.IData.Book
{
    public interface IBookRepository
    {
        Task<int> AddBook(Bookshelf.Domain.Book.Book book);
        Task<Bookshelf.Domain.Book.Book> GetBook(int bookId);
        Task<Bookshelf.Domain.Book.Book> GetBook(string title);
        Task EditBook(Domain.Book.Book book);
        // nowe
        //Task<Bookshelf.Domain.Book.Book> DeleteBook(int bookId);
        Task DeleteBook(Domain.Book.Book book);
    }
}