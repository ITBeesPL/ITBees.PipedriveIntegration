namespace ITBees.PipedriveIntegration.Models;

public class LeadRequest
{
    public string Title { get; set; }
    public int PersonId { get; set; }
    public int OrganizationId { get; set; }
    public string Note { get; set; }
}