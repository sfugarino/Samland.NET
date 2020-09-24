using DotnetApi.Contexts;
using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
    public class ArtistRepository : IArtistRepository, IDisposable
    {
        private MusicDbContext context;

        public ArtistRepository(MusicDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Artist>> Get()
        {
            return await context.Artists.ToListAsync();
        }

        public async Task<Artist> GetById(Guid id)
        {
            var artist = await context.Artists
            .Include(a => a.Members)
            .Include(a => a.Albums).ThenInclude(al => ((Album)al).Songs)
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
