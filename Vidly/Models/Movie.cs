using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
   public class Movie
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public Genre Genre { get; set; }

      [Display(Name = "Genre")]
      [Required]
      public byte GenreId { get; set; }

      [Display(Name = "Release Date")]
      [Required]
      public DateTime ReleaseDate { get; set; }

      [Required]
      [Display(Name = "Date Added")]
      public DateTime DateAdded { get; set; }

      [Required]
      [Display(Name = "Number in Stock")]
      [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
      public byte NumberInStock { get; set; }

      [Display(Name = "Number Available")]
      public byte NumberAvailable { get; set; }
   }
}
