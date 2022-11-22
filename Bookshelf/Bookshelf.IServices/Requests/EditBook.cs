namespace Bookshelf.IServices.Requests;

public class EditBook
{
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public int PagesNumber { get; set; }
}