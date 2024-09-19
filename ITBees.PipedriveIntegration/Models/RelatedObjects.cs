namespace ITBees.PipedriveIntegration.Models;

public class RelatedObjects
{
    public Dictionary<string, Organization> Organization { get; set; }
    public Dictionary<int, User> User { get; set; }
    public Dictionary<int, Picture> Picture { get; set; }
}