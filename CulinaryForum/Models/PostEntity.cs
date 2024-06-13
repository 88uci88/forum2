namespace CulinaryForum.Models;

public class PostEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime PostedDate { get; set; }

    public UserEntity Author { get; set; }
    public string AuthorId { get; set; }
}