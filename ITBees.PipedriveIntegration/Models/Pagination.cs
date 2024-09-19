namespace ITBees.PipedriveIntegration.Models;

public class Pagination
{
    public int Start { get; set; }
    public int Limit { get; set; }
    public bool MoreItemsInCollection { get; set; }
}