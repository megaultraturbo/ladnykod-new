namespace Bookshelf.Data.SQL.DAO;

public class User
{
    public User()
    {
        Reviews = new List<Review>();
        ReviewPreferences = new List<ReviewPreference>();
        AuthorPreferences = new List<AuthorPreference>();
        BookPreferences = new List<BookPreference>();

    }
    
    
    public int UserId { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<ReviewPreference> ReviewPreferences { get; set; }
    public virtual ICollection<AuthorPreference> AuthorPreferences { get; set; }
    public virtual ICollection<BookPreference> BookPreferences { get; set; }

}