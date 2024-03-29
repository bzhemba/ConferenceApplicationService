using Application.Models;
using AutoMapper;
using ConferenceApplicationService.Application.Queries.GetApplicationById;
using MediatR;

namespace ConferenceApplicationService.Application.Queries.GetCurrentDraft;

public class GetCurrentDraftQuery : IRequest<ApplicationInformationVm>
{
    public Guid UserId;
}