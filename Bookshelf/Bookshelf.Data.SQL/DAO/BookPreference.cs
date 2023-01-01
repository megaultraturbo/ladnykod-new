namespace Bookshelf.Data.SQL.DAO;

public class BookPreference
{
  public int BookPreferenceId { get; set; }
  public int UserId { get; set; }
  public int BookId { get; set; }

  public bool Reading { get; set; }
  public bool WantToRead { get; set; }
  public bool Finished { get; set; }
  public bool Favorite { get; set; }
  public int UserRating { get; set; }

  public User User { get; set; }
  public Book Book { get; set; }
}