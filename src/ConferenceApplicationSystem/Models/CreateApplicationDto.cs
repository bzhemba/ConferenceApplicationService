using Application.Models;
using Applications.Mapping;
using AutoMapper;
using ConferenceApplicationService.Application.Commands.CreateCommand;

namespace ConferenceApplicationSystem.Models;

public class CreateApplicationDto : IMapWith<CreateApplicationCommand>
{
    public Guid UserId { get; }
    public string Title { get; }
    public ActivityType Activity { get; }
    public string? Description { get; }
    public string Outline { get; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateApplicationDto, CreateApplicationCommand>()
            .ForMember(applicationCommand => applicationCommand.UserId,
                opt =>
                    opt.MapFrom(applicationDto => applicationDto.UserId))
            .ForMember(applicationCommand => applicationCommand.Activity,
                opt =>
                    opt.MapFrom(applicationDto => applicationDto.Activity))
            .ForMember(applicationCommand => applicationCommand.Title,
                opt =>
                    opt.MapFrom(applicationDto => applicationDto.Title))
            .ForMember(applicationCommand => applicationCommand.Description,
                opt =>
                    opt.MapFrom(applicationDto => applicationDto.Description))
            .ForMember(applicationCommand => applicationCommand.Outline,
                opt =>
                    opt.MapFrom(applicationDto => applicationDto.Outline));
    }
}