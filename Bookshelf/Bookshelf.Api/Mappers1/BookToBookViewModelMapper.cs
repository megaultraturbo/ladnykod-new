using Bookshelf.Api.ViewModels;

namespace Bookshelf.Api.Mappers1;

public class BookToBookViewModelMapper
{
    public static BookViewModel BookToBookViewModel(Domain.Book.Book book)
    {
        var bookViewModel = new BookViewModel
        {
            BookId = book.BookId,
            AuthorId = book.AuthorId,
            Title = book.Title,
            PagesNumber = book.PagesNumber
        };
        return bookViewModel;
    }
}