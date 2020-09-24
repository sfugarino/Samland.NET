using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface ISong
    {
        Guid Id { get; }
        string Name { get; set; }
        Guid? AlbumId { get; set; }
        Album Album { get; set; }
        Guid ArtistId { get; set; }
        Artist Artist { get; set; }
    }

    public class Song : ISong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        [JsonIgnore]
        public virtual Artist Artist { get; set; }

        public Guid? AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        [JsonIgnore]
        public virtual Album Album { get; set; }
    }
}
