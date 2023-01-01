namespace Bookshelf.Data.SQL.DAO;

public class Review
{
  public Review()
  {
    ReviewPreferences = new List<ReviewPreference>();
  }

  public int ReviewId { get; set; }
  public int UserId { get; set; }
  public int BookId { get; set; }

  public string ReviewText { get; set; }
  public int LikeCtr { get; set; }
  public int DislikeCtr { get; set; }

  public virtual User User { get; set; }
  public virtual Book Book { get; set; }

  public virtual ICollection<ReviewPreference> ReviewPreferences { get; set; }
}