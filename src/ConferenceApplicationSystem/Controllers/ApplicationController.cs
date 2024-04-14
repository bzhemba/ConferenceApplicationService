using AutoMapper;
using ConferenceApplicationService.Application.Commands.CreateCommand;
using ConferenceApplicationService.Application.Commands.DeleteCommand;
using ConferenceApplicationService.Application.Commands.EditCommand;
using ConferenceApplicationService.Application.Commands.SendCommand;
using ConferenceApplicationService.Application.Queries.GetApplicationById;
using ConferenceApplicationService.Application.Queries.GetApplicationsByDate;
using ConferenceApplicationService.Application.Queries.GetCurrentDraft;
using ConferenceApplicationService.Application.Queries.GetUnsubmittedApplicationByDate;
using ConferenceApplicationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceApplicationSystem.Controllers;
[Microsoft.AspNetCore.Components.Route("api/application")]
public class ApplicationController : BaseController
{
    private readonly IMapper _mapper;

    public ApplicationController(IMapper mapper) => _mapper = mapper;

    [HttpGet("{date:datetime}",  Name="GetByDate")]
    public async Task<ActionResult<ApplicationsListVm>> GetByDate(DateTime date)
    {
        var query = new GetApplicationsByDateQuery(date);
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApplicationInformationVm>> GetById(Guid id)
    {
        var query = new GetApplicationByIdQuery(id);
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpGet("{date:datetime}")]
    public async Task<ActionResult<ApplicationsListVm>> GetUnsubmittedByDate(DateTime date)
    {
        var query = new GetUnsubmittedApplicationByDateQuery(date);
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<ApplicationInformationVm>> GetUnsubmittedByUserId(Guid userId)
    {
        var query = new GetCurrentDraftQuery(userId);
        var vm = await Mediator.Send(query);
        
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateApplicationDto createApplicationDto)
    {
        var command = _mapper.Map<CreateApplicationCommand>(createApplicationDto);
        var noteId = await Mediator.Send(command);
        return Ok(noteId);
    }
    [HttpPost("{id:guid}")]
    public async Task<ActionResult> ChangeStatus(Guid id)
    {
        var command = _mapper.Map<SendApplicationCommand>(id);
        var noteId = await Mediator.Send(command);
        return Ok(noteId);
    }

    [HttpPut]
    public async Task<ActionResult<ApplicationInformationVm>> Update([FromBody] EditApplicationDto editNoteDto)
    {
        var command = _mapper.Map<EditApplicationCommand>(editNoteDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteApplicationCommand(id);
        await Mediator.Send(command);
        return NoContent();
    }
}