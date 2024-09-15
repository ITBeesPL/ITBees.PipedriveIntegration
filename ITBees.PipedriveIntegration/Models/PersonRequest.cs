namespace ITBees.PipedriveIntegration.Models;

public class PersonRequest
{
    public string Name { get; set; }
    public List<EmailField> Email { get; set; }
    public List<PhoneField> Phone { get; set; }
}