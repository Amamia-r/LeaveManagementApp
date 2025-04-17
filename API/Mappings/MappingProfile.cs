using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequestCreateDto, LeaveRequest>();
    }
}

