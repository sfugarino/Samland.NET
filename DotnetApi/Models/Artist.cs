using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface IArtist
    {
        Guid Id { get; }
        string Name { get; set; }
        Genre Genre { get; set; }
        string ImageUrl { get; set; }
        List<BandMember> Members { get; set; }
        List<Album>Albums { get; set; }
        List<Song> Songs { get; set; }
    }

    public class Artist : IArtist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<BandMember> Members { get; set; }

        public List<Album> Albums { get; set; }

        public List<Song> Songs { get; set; }
    }
}
