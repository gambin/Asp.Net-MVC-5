using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{

    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number Available")]
        [Range(0, 20)]
        public int NumberAvailable { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Genre")]
        public int GenderId { get; set; }
        public Movie()
        {
            // ReleaseDate = new DateTime();
        }
    }
}

