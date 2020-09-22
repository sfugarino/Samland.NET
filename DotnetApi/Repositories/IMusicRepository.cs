using DotnetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Artist>> GetArtists();
        Task<Artist> GetArtist(Guid id);
        void Save();
    }
}
