namespace ITBees.PipedriveIntegration.Models;

public class PictureId
{
    public string ItemType { get; set; }
    public int ItemId { get; set; }
    public bool ActiveFlag { get; set; }
    public string AddTime { get; set; }
    public string UpdateTime { get; set; }
    public int AddedByUserId { get; set; }
    public object FileSize { get; set; }
    public Dictionary<string, string> Pictures { get; set; }
    public int Value { get; set; }
}