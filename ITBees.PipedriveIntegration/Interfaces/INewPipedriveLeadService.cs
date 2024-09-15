using ITBees.Interfaces.ExternalSalesPlatformIntegration.Models;

namespace ITBees.PipedriveIntegration.Interfaces;

public interface INewPipedriveLeadService
{
    Task<NewLeadCreateResultVm> Create(NewLeadIm newLeadIm);
}