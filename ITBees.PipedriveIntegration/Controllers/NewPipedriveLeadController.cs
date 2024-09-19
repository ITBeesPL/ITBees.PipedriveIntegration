using ITBees.Interfaces.ExternalSalesPlatformIntegration.Models;
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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] NewLeadIm newLeadIm)
    {
        return await ReturnOkResultAsync(() => _newPipedriveLeadService.CreateLead(newLeadIm));
    }
}