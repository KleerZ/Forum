namespace Recommendations.Domain;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Discussion> Discussions { get; set; } = new();
}