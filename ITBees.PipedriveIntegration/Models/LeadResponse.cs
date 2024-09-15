namespace ITBees.PipedriveIntegration.Models;

public class LeadResponse
{
    public bool Success { get; set; }
    public LeadData Data { get; set; }
    public object AdditionalData { get; set; }
}