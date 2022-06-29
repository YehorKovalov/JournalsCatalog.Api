using System.Net;
using JournalCatalog.Api.Models;
using JournalCatalog.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JournalCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JournalCatalogBffController : ControllerBase
{
    private readonly IJournalService _journalService;

    public JournalCatalogBffController(IJournalService journalService) => _journalService = journalService;

    [HttpPost]
    [ProducesResponseType(typeof(AddJournalResponse<JournalDto>), (int)HttpStatusCode.OK)]
    public IActionResult Add(AddJournalRequest request)
    {
        var result = _journalService.AddJournal(request.FullName, request.Date, request.Attendance);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllJournalsResponse<JournalDto>), (int)HttpStatusCode.OK)]
    public IActionResult GetAll()
    {
        var result = _journalService.GetAllJournalsOrEmpty();
        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(GetJournalByIdResponse<JournalDto>), (int)HttpStatusCode.OK)]
    public IActionResult GetById(Guid id)
    {
        var result = _journalService.GetJournalByIdOrDefault(id);
        return Ok(result);
    }

    [HttpPatch("{id:Guid}")]
    [ProducesResponseType(typeof(UpdateJournalResponse<JournalDto>), (int)HttpStatusCode.OK)]
    public IActionResult Update(Guid id, UpdateJournalRequest request)
    {
        var result = _journalService.UpdateJournalById(id, request.FullName, request.Date, request.Attendance);
        return Ok(result);
    }

    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(typeof(DeleteJournalByIdResponse<bool>), (int)HttpStatusCode.OK)]
    public IActionResult Delete(Guid id)
    {
        var result = _journalService.DeleteJournalById(id);
        return Ok(result);
    }
}