using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Bookshelf.Data.SQL.DAO;

public class Book
{
    public Book()
    {
        Reviews = new List<Review>();
        BookPreferences = new List<BookPreference>();
    }
    
    public int BookId { get; set; }
    public int AuthorId { get; set; }

    public string Title { get; set; }
    public int PagesNumber { get; set; }
    //public int FavoritesCtr { get; set; }
    
    public virtual Author Author { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<BookPreference> BookPreferences { get; set; }
    
}