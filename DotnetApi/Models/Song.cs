using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetApi.Models
{
    public interface ISong
    {
        Guid Id { get; }
        string Name { get; set; }
    }

    public class Song : ISong
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }
    }
}
