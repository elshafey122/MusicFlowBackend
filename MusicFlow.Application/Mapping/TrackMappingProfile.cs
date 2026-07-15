using AutoMapper;
using MusicFlow.Application.Dto;
using MusicFlow.Application.Features.Track.Commands.Model;
using MusicFlow.Domain.Entites;
using MusicFlow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace ProductService.Application.Mapping
{
    public class TrackMappingProfile : Profile
    {
        public TrackMappingProfile()
        {
            CreateMap<Track, TrackDto>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<TrackDto, Track>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<TrackStatus>(src.Status, true)));


            CreateMap<CreateTrackCommand, Track>().ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<TrackStatus>(src.Status, true)));
            CreateMap<DSP, DspDto>();
            CreateMap<TrackDistribution, DspDto>().ForMember(des => des.DspStatus, opt => opt.MapFrom(src => src.Status.ToString()))
                                                  .ForMember(des => des.DspName, opt => opt.MapFrom(src => src.Dsp.Name))
                                                  .ForMember(des => des.DspId, opt => opt.MapFrom(src => src.Dsp.Id));

            CreateMap<Track, TrackDspsDto>().ForMember(des => des.Dsps, opt => opt.MapFrom(src => src.TrackDistributions));
        }
    }
}
