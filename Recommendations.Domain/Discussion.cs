using System.ComponentModel.DataAnnotations.Schema;

namespace Recommendations.Domain;

public class Discussion
{
    [NotMapped]
    public string ObjectID { get; set; }
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }

    public User User { get; set; }
    public List<Tag> Tags { get; set; } = new();
    public Category Category { get; set; }
    public Theme Theme { get; set; } = new();
    public List<Like> Likes { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Image>? Images { get; set; } = new();
}