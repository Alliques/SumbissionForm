using Microsoft.AspNetCore.Mvc;
using SubmittingForm.Application;
using System.Text.Json;

namespace SubmittingForm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubmissionsController : ControllerBase
{
    private readonly SubmissionService _service;

    public SubmissionsController(SubmissionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] JsonElement payload)
    {
        var id = await _service.CreateAsync(payload);
        return Ok(new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? search)
    {
        var result = await _service.SearchAsync(search);
        return Ok(result);
    }
}