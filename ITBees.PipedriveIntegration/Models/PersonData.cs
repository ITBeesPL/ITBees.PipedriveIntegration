namespace ITBees.PipedriveIntegration.Models;

public class PersonData
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public List<EmailField> Email { get; set; } 
    public List<PhoneField> Phone { get; set; }
    public int? OrgId { get; set; } 
    public int OwnerId { get; set; } 
    public string AddTime { get; set; }
    public string UpdateTime { get; set; } 
    public bool ActiveFlag { get; set; }
}