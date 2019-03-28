using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
   public class MovieDto
   {
      public int Id { get; set; }
      public string Name { get; set; }

      [Required]
      public byte GenreId { get; set; }

      public GenreDto Genre { get; set; }

      [Required]
      public DateTime ReleaseDate { get; set; }

      [Required]
      public DateTime DateAdded { get; set; }

      [Range(1, 20)]
      public byte NumberInStock { get; set; }
   }
}