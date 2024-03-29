using Application.Models;
using AutoMapper;
using MediatR;

namespace ConferenceApplicationService.Application.Queries.GetApplicationById;

public class GetApplicationByIdQuery : IRequest<ApplicationInformationVm>
{
    public Guid Id;
}