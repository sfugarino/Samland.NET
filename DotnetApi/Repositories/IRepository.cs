using DotnetApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(Guid id);
        void Update(TEntity entity);
        void Save();
    }

    public interface IArtistRepository: IRepository<Artist>
    {

    }

    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IEnumerable<Album>> GetForArtist(Guid artistId);
    }


}
