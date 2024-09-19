
namespace ITBees.PipedriveIntegration.Models;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int HasPic { get; set; }
    public string PicHash { get; set; }
    public bool ActiveFlag { get; set; }
    public int Value { get; set; }
}