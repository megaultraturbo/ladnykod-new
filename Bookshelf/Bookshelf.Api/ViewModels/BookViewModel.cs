using System;

namespace Bookshelf.Api.ViewModels{

    public class BookViewModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; }
        public int PagesNumber { get; set; }
    }
}