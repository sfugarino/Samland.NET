using DotnetApi.Contexts;
using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
    public class AlbumRepository : IAlbumRepository, IDisposable
    {
        private MusicDbContext context;

        public AlbumRepository(MusicDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Album>> Get()
        {
            return await context.Albums
                .Include(a => a.Songs)
                .ToListAsync();
        }

        public async Task<Album> GetById(Guid id)
        {
            var artist = await context.Albums
            .Include(a => a.Songs)
            .SingleOrDefaultAsync(a => a.Id == id);

            return artist;
        }

        public async Task<IEnumerable<Album>> GetForArtist(Guid artistId)
        {
            var artists = await context.Albums
            .Include(a => a.Songs)
            .Where(a => a.ArtistId == artistId)
            .ToListAsync();
            return artists;
        }

        public void Update(Album album)
        {
            var dbAlbum = context.Albums
                .Where(a => a.Id == album.Id)
                .Include(a => a.Songs)
                .SingleOrDefault();

            if (dbAlbum != null)
            {
                // Update parent
                context.Entry(dbAlbum).CurrentValues.SetValues(album);

                // Delete children
                foreach (var song in dbAlbum.Songs.ToList())
                {
                    if (!album.Songs.Any(s => s.Id == song.Id))
                    {
                        var dbSong = dbAlbum.Songs
                        .Where(s => s.Id == song.Id)
                        .SingleOrDefault();

                        dbSong.AlbumId = null;
                    }
                }

                // Update and Insert children
                foreach (var song in album.Songs)
                {
                    var dbSong = dbAlbum.Songs
                        .Where(c => c.Id == song.Id)
                        .SingleOrDefault();

                    if (dbSong != null)
                        // Update child
                        context.Entry(dbSong).CurrentValues.SetValues(song);
                    else
                    {
                        // Insert child
                        var newSong = new Song
                        {
                            Name = song.Name,
                            ArtistId = song.ArtistId,
                            AlbumId = song.AlbumId
                        };
                        dbAlbum.Songs.Add(song);
                    }
                }

                context.SaveChanges();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
