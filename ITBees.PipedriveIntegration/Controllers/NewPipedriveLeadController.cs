using ITBees.PipedriveIntegration.Interfaces;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.PipedriveIntegration.Controllers;

public class NewPipedriveLeadController : RestfulControllerBase<NewPipedriveLeadController>
{
    private readonly INewPipedriveLeadService _newPipedriveLeadService;

    public NewPipedriveLeadController(ILogger<NewPipedriveLeadController> logger,
        INewPipedriveLeadService newPipedriveLeadService) : base(logger)
    {
        _newPipedriveLeadService = newPipedriveLeadService;
    }

    public IActionResult Post([FromBody] NewPipedriveLeadIm newPipedriveLeadIm)
    {
        return ReturnOkResult(()=>_newPipedriveLeadService.Create(newPipedriveLeadIm));
    }
}