using Microsoft.EntityFrameworkCore;
using MusicFlow.Domain.Entites;
using MusicFlow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Persistence.SeedData
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var artistId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var artistId2 = Guid.Parse("10000000-1111-1111-1111-111111111111");
            var artistId3 = Guid.Parse("20000000-1111-1111-1111-111111111111");

            var DSPId = Guid.Parse("11111111-2222-2222-2222-222222222222");
            var DSPId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var DSPId3 = Guid.Parse("33333333-2222-2222-2222-222222222222");

            var trackid = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var trackid2 = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var trackid3 = Guid.Parse("55555555-3333-3333-3333-333333333333");
            var trackid4 = Guid.Parse("66666666-4444-4444-4444-444444444444");
            var trackid5 = Guid.Parse("77777777-3333-3333-3333-333333333333");
            var trackid6 = Guid.Parse("88888888-4444-4444-4444-444444444444");
            var trackid7 = Guid.Parse("99999999-3333-3333-3333-333333333333");
            var trackid8 = Guid.Parse("11112211-4444-4444-4444-444444444444");

            modelBuilder.Entity<Artist>().HasData(
            new Artist
            {
                Id = artistId,
                Name = "Ahmed Ali",
                Email = "ahmed@test.com",
                Country = "Egypt"
            },
            new Artist
            {
                Id = artistId2,
                Name = "Tamer Nour",
                Email = "tamer@test.com",
                Country = "Tunis"
            },
            new Artist
            {
                Id = artistId3,
                Name = "Mona Yasser",
                Email = "mona@test.com",
                Country = "Saudia"
            })
                ;

            modelBuilder.Entity<Track>().HasData(
            new Track
            {
                Id = trackid,
                Title = "Track 1",
                ArtistId = artistId,
                ReleaseDate = new DateOnly(2023, 1, 1),
                ISRC = "US-AAA-23-00001",
                Status = TrackStatus.Distributed,
                Genre = "Pop"
            },
            new Track
            {
                Id = trackid2,
                Title = "Track 2",
                ArtistId = artistId2,
                ReleaseDate = new DateOnly(2024, 1, 1),
                ISRC = "US-AAA-93-00002",
                Status = TrackStatus.Submitted,
                Genre = "Pop"
            }, new Track
            {
                Id = trackid3,
                Title = "Track 3",
                ArtistId = artistId3,
                ReleaseDate = new DateOnly(2020, 1, 1),
                ISRC = "US-AAA-23-00003",
                Status = TrackStatus.Distributed,
                Genre = "Pop"
            },
            new Track
            {
                Id = trackid4,
                Title = "Track 4",
                ArtistId = artistId2,
                ReleaseDate = new DateOnly(2021, 1, 1),
                ISRC = "US-AAA-93-00004",
                Status = TrackStatus.Submitted,
                Genre = "Pop"
            },
            new Track
            {
                Id = trackid5,
                Title = "Track 5",
                ArtistId = artistId,
                ReleaseDate = new DateOnly(2025, 1, 1),
                ISRC = "US-AAA-23-00005",
                Status = TrackStatus.Distributed,
                Genre = "Pop"
            },
            new Track
            {
                Id = trackid6,
                Title = "Track 6",
                ArtistId = artistId2,
                ReleaseDate = new DateOnly(2026, 1, 1),
                ISRC = "US-AAA-93-00006",
                Status = TrackStatus.Submitted,
                Genre = "Pop"
            },
            new Track
            {
                Id = trackid7,
                Title = "Track 7",
                ArtistId = artistId,
                ReleaseDate = new DateOnly(2019, 1, 1),
                ISRC = "US-AAA-23-00007",
                Status = TrackStatus.Distributed,
                Genre = "Pop"
            },
            new Track
            {
                Id = trackid8,
                Title = "Track 8",
                ArtistId = artistId2,
                ReleaseDate = new DateOnly(2018, 1, 1),
                ISRC = "US-AAA-93-00008",
                Status = TrackStatus.Submitted,
                Genre = "Pop"
            });

            modelBuilder.Entity<DSP>().HasData(
            new DSP
            {
                Id = DSPId,
                Name = "Spotify"
            },
            new DSP
            {
                Id = DSPId2,
                Name = "Youtube"
            },
            new DSP
            {
                Id = DSPId3,
                Name = "TickTock"
            });
        }
    }
}
