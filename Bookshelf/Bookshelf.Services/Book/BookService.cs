using System.Threading.Tasks;
using Bookshelf.IData.Book;
using Bookshelf.IServices.Requests;
using Bookshelf.IServices.Book;

namespace Bookshelf.Services.Book
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Domain.Book.Book> GetBookByBookId(int bookId)
        {
            return _bookRepository.GetBook(bookId);
        }

        public Task<Domain.Book.Book> GetBookByTitle(string title)
        {
            return _bookRepository.GetBook(title);
        }

        public async Task<Domain.Book.Book> CreateBook(CreateBook createBook)
        {
            var book = new Domain.Book.Book(createBook.AuthorId, createBook.Title, createBook.PagesNumber);
            book.BookId = await _bookRepository.AddBook(book);
            return book;
        }

        public async Task EditBook(EditBook createBook, int bookId)
        {
            var book = await _bookRepository.GetBook(bookId);
            book.EditBook(createBook.AuthorId, createBook.Title, createBook.PagesNumber);
            await _bookRepository.EditBook(book);
        }
        
        //nowe
        public async Task DeleteBook(int bookId)
        {
            var book = await _bookRepository.GetBook(bookId);
            await _bookRepository.DeleteBook(book);
        }
    }

}