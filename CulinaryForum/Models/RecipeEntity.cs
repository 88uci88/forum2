namespace CulinaryForum.Models;

public class RecipeEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime PostedDate { get; set; }

    public string AuthorId { get; set; }
    public UserEntity Author { get; set; }
}