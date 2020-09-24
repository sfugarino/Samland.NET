using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetApi.Models;
using DotnetApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotnetApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private readonly IAlbumRepository repository;

        public AlbumController(IAlbumRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<ArtistController>
        [HttpGet]
        public async Task<IEnumerable<Album>> Get()
        {
            return await repository.Get();
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public async Task<Album> Get(Guid id)
        {
            return await repository.GetById(id);
        }

        [HttpGet("artist/{id}")]
        public async Task<IEnumerable<Album>> GetForArtist(Guid id)
        {
            return await repository.GetForArtist(id);
        }

        // POST api/<AlbumController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
