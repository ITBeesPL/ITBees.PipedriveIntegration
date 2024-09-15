namespace ITBees.PipedriveIntegration.Models;

public class PipedriveResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public object AdditionalData { get; set; }
}