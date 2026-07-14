using AutoMapper;
using MusicFlow.Application.Dto;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProductService.Application.Mapping
{
    public class TrackMappingProfile : Profile
    {
        public TrackMappingProfile()
        {
            CreateMap<Track, TrackDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
