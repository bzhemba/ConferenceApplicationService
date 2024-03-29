using Application.Models;
using Applications.Mapping;
using AutoMapper;

namespace ConferenceApplicationService.Application.Queries.GetApplicationById;

public class ApplicationInformationVm : IMapWith<global::Application.Models.Application>
{
    public Guid UserId;
    public Guid Id;
    public string Title;
    public Activity Activity;
    public string? Description;
    public string Outline;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<global::Application.Models.Application, ApplicationInformationVm>()
            .ForMember(applicationVm => applicationVm.Id,
                opt =>
                    opt.MapFrom(application => application.Id))
            .ForMember(applicationVm => applicationVm.UserId,
                opt =>
                    opt.MapFrom(application => application.UserId))
            .ForMember(applicationVm => applicationVm.Title,
                opt =>
                    opt.MapFrom(application => application.Title))
            .ForMember(applicationVm => applicationVm.Description,
                opt =>
                    opt.MapFrom(application => application.Description))
            .ForMember(applicationVm => applicationVm.Outline,
                opt =>
                    opt.MapFrom(application => application.Outline));
        
    }
}