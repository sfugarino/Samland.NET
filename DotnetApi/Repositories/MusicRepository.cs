using DotnetApi.Contexts;
using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
    public class MusicRepository : IMusicRepository, IDisposable
    {
        private MusicDbContext context;

        public MusicRepository(MusicDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            return await context.Artist.ToListAsync();
        }

        public async Task<Artist> GetArtist(Guid id)
        {
            var artist = await context.Artist
               .Include(a => a.Albums)
                .ThenInclude(al => al.Songs)
               .SingleOrDefaultAsync(a => a.Id == id);

            return artist;
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
