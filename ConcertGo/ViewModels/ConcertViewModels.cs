using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConcertGo.ViewModels
{
    public class ConcertViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Concert Name")]
        public string Name { get; set; }
    }

    public class ConcertDetailViewModel : ConcertViewModel
    {
        [DisplayName("Artists")]
        public IEnumerable<ArtistViewModel> Artists { get; set; }

        [DisplayName("Media")]
        public IEnumerable<MediaViewModel> Media { get; set; }
    }
}