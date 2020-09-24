using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface IAlbum
    {
        Guid Id { get; }
        string Name { get; set; }
        DateTime? ReleaseDate { get; set; }
        string ImageUrl { get; set; }
        List<Song> Songs { get; set; }
        Guid ArtistId { get; set; }

        
        Artist Artist { get; set; }
    }


    public class Album : IAlbum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<Song> Songs { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        [JsonIgnore]
        public virtual Artist Artist { get; set; }
    }
}
