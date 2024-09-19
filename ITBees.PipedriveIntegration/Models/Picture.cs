namespace ITBees.PipedriveIntegration.Models;

public class Picture
{
    public int Id { get; set; }
    public string ItemType { get; set; }
    public int ItemId { get; set; }
    public bool ActiveFlag { get; set; }
    public string AddTime { get; set; }
    public string UpdateTime { get; set; }
    public int AddedByUserId { get; set; }
    public object FileSize { get; set; }
    public Dictionary<string, string> Pictures { get; set; }
}