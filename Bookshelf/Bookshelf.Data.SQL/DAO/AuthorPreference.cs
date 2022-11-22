namespace Bookshelf.Data.SQL.DAO;

public class AuthorPreference
{
    public int AuthorPreferenceId { get; set; }
    public int UserId { get; set; }
    public int AuthorId { get; set; }
    
    public bool Like { get; set; }
    public bool Dislike { get; set; }
    public bool Favorite { get; set; }
    
    public User User { get; set; }
    public Author Author { get; set; }
}