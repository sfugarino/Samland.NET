using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface IBandMember
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Guid ArtistId { get; set; }
        Artist Artist { get; set; }
    }

    public class BandMember : IBandMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }

    }
}
