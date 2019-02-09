using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string Actor { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string DateOfRelease { get; set; }
    }
}
