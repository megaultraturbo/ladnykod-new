namespace Bookshelf.Data.SQL.DAO;

public class Author
{
  public Author()
  {
    Books = new List<Book?>();
    AuthorPreferences = new List<AuthorPreference?>();
  }

  public int AuthorId { get; set; }

  public string FirstName { get; set; }
  public string LastName { get; set; }
  //public int LikesCtr { get; set; }

  public virtual ICollection<Book> Books { get; set; }
  public virtual ICollection<AuthorPreference> AuthorPreferences { get; set; }
}