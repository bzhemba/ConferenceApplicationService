using Application.Models;
using AutoMapper;
using ConferenceApplicationService.Application.Queries.GetApplicationById;

namespace ConferenceApplicationService.Application.Queries.GetApplicationsByDate;

public class ApplicationsListVm
{
    public IList<ApplicationInformationVm> Applications;

    public ApplicationsListVm(IList<ApplicationInformationVm> applications)
    {
        Applications = applications;
    }
}