using ITBees.PipedriveIntegration.Controllers;

namespace ITBees.PipedriveIntegration.Interfaces;

public interface INewPipedriveLeadService
{
    NewPipedriveLeadCreateResultVm Create(NewPipedriveLeadIm newPipedriveLeadIm);
}