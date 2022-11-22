namespace Bookshelf.IServices.Requests;

public class CreateBook
{
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public int PagesNumber { get; set; }
    
}