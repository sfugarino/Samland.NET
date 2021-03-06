﻿using System;
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
    public class ArtistController : ControllerBase
    {

        private readonly IArtistRepository repository;

        public ArtistController(IArtistRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<ArtistController>
        [HttpGet]
        public async Task<IEnumerable<Artist>> Get()
        {
            return await repository.Get();
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public async Task<Artist> Get(Guid id)
        {
            return await repository.GetById(id);
        }

        // POST api/<ArtistController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
