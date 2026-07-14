using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Artist.Queires.Model
{
    public class GetAllArtistsQuery : IRequest<Response<List<ArtistDto>>>
    {

    }
}
