using System;
using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Activity, ReadActivityDto>();
        CreateMap<CreateActivityDto, Activity>();
        CreateMap<Activity, FullActivityDto>();
        CreateMap<FullActivityDto, Activity>();
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<Comment, ReadCommentDto>();
    }
}
