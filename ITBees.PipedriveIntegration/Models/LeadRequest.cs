namespace ITBees.PipedriveIntegration.Models;

public class LeadRequest
{
    public string Title { get; set; }
    public int PersonId { get; set; }
    public int OrganizationId { get; set; }
    public string Note { get; set; }
    public string Label { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? SourceName { get; set; }
}


public class NewLeadRequest
{
    public string Title { get; set; }
    public int OwnerId { get; set; }
    public List<Guid> LabelIds { get; set; }
    public int PersonId { get; set; }
    public int OrganizationId { get; set; }
    public LeadValue Value { get; set; }
    public DateTime ExpectedCloseDate { get; set; }
    public string VisibleTo { get; set; }
    public bool WasSeen { get; set; }
    public string OriginId { get; set; }
    public int Channel { get; set; }
    public string ChannelId { get; set; }
    public string? SourceName { get; set; }
    public string? Email { get; set; }
}

public class LeadValue
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
