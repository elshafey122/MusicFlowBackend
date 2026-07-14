using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using artist = MusicFlow.Domain.Entites.Artist;

namespace MusicFlow.Application.Features.Artist.Commands.Model
{
    public class CreateArtistCommand : IRequest<Response<ArtistDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}
