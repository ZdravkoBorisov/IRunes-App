using System;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Models
{
    public class Track
    {
        public Track()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string AlbumId { get; set; }

        public Album Album { get; set; }

    }
}
