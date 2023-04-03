namespace Recommendations.Domain;

public class Theme
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Discussion> Discussions { get; set; } = new();
}