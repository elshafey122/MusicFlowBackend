using AutoMapper;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Artist.Commands.Model;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Application.Mapping
{
    public class ArtistMappingProfile : Profile
    {
        public ArtistMappingProfile()
        {
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<CreateArtistCommand, Artist>();
        }
    }
}
