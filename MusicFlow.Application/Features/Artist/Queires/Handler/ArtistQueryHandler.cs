using MediatR;
using MusicFlow.Application.Features.Artist.Dto;
using MusicFlow.Application.Features.Artist.Queires.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Artist.Commands.Handler
{
    public class ArtistQueryHandler : ResponseHandler, IRequestHandler<GetAllArtistsQuery, Response<List<ArtistDto>>>
    {
        public Task<Response<List<ArtistDto>>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
