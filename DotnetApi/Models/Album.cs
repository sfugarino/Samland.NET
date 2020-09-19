using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface IAlbum
    {
        Guid Id { get; }
        string Name { get; set; }
        DateTime? ReleaseDate { get; set; }
        string ImageUrl { get; set; }
        Song[] Songs { get; set; }
    }

    public class Album : IAlbum
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public Song[] Songs { get; set; }
    }
}
