﻿using System.ComponentModel.DataAnnotations;

namespace lec5MVCL.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        //Navigation props:
        public Album? Album { get; set; }
        public int? AlbumId { get; set; }
    }
}
