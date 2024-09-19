namespace ITBees.PipedriveIntegration.Models;

public class OrgId
{
    public string Name { get; set; }
    public int PeopleCount { get; set; }
    public int OwnerId { get; set; }
    public string Address { get; set; }
    public bool ActiveFlag { get; set; }
    public string CcEmail { get; set; }
    public List<int> LabelIds { get; set; }
    public string OwnerName { get; set; }
    public int Value { get; set; }
}