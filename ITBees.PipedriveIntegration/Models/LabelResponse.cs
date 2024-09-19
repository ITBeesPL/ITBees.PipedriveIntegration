namespace ITBees.PipedriveIntegration.Models;

public class LabelResponse
{
    public bool Success { get; set; }
    public List<LabelData> Data { get; set; }
}

public class NewLabelResponse
{
    public bool Success { get; set; }
    public LabelData Data { get; set; }
}