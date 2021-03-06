﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConcertGo.ViewModels
{
    public class ArtistViewModels
    {
    }

    public class ArtistViewModel
    {
        [DisplayName("Artist Name")]
        public string Name { get; set; }
    }

    public class CreateArtistViewModel
    {
        [Required]
        [DisplayName("Artist Name")]
        public string ArtistName { get; set; }

        [DisplayName("Concert Name")]
        public string ConcertName { get; set; }
    }

    public class ArtistDetailViewModel
    {
        public Guid ArtistId { get; set; }

        public string ArtistName { get; set; }

        public string NewConcertName { get; set; }
    }
}