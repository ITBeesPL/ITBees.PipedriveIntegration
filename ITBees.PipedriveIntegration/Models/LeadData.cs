namespace ITBees.PipedriveIntegration.Models;

public class LeadData
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PersonId { get; set; }
    public int OrganizationId { get; set; }
    public string AddTime { get; set; } 
    public string Note { get; set; }
}