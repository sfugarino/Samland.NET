using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface IArtist
    {
        Guid Id { get; }
        string Name { get; set; }
        Genre Genre { get; set; }
        public string ImageUrl { get; set; }
        public string[] Members { get; set; }
        public Album[] Albums { get; set; }
    }

    public class Artist : IArtist
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string[] Members { get; set; }

        public Album[] Albums { get; set; }
    }
}
