using ITBees.PipedriveIntegration.Models;

namespace ITBees.PipedriveIntegration.Interfaces;

public interface IPipedriveConnectorService
{
    Task<List<Person>> GetUsers();
}