namespace Bookshelf.Data.SQL.DAO;

public class ReviewPreference
{
  public int ReviewPreferenceId { get; set; }
  public int ReviewId { get; set; }
  public int UserId { get; set; }

  public bool Like { get; set; }
  public bool Dislike { get; set; }

  public virtual User User { get; set; }
  public virtual Review Review { get; set; }
}