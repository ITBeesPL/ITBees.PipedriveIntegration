namespace ITBees.PipedriveIntegration.Models;

public class ApiResponse
{
    public bool Success { get; set; }
    public List<Person> Data { get; set; }
    public AdditionalData AdditionalData { get; set; }
    public RelatedObjects RelatedObjects { get; set; }
}