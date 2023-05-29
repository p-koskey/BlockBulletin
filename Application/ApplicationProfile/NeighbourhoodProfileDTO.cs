using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.ApplicationProfile;

public class NeighbourhoodProfileDTO : Profile
{
    public NeighbourhoodProfileDTO()
    {
        CreateMap<Entity, EntityDTO>().ReverseMap();
        CreateMap<Neighbourhood, NeighbourhoodDTO>().ReverseMap();
        CreateMap<Post, PostDTO>().ReverseMap();
        CreateMap<Business, BusinessDTO>().ReverseMap();
    }
}