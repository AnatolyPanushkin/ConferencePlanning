using ConferencePlanning.Data.Entities;
using ConferencePlanning.Services.ConferenceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferencePlanning.Controllers;

[Route("api/conferences")]
[ApiController]

public class ConferenceApiController:ControllerBase
{
    private readonly IConferenceService _service;

    public ConferenceApiController(IConferenceService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IActionResult GetConferences()
    {
        return Ok(_service.GetAllConferences());
    }
}