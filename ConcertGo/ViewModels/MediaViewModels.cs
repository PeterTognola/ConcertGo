using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConcertGo.ViewModels
{
    public class MediaViewModel
    {
        public string Comment { get; set; }

        public IEnumerable<FileViewModel> Files { get; set; }
    }

    public class CreateMediaViewModel
    {
        [Required]
        public Guid ConcertId { get; set; }

        [Required]
        public string Comment { get; set; }

        //[Required]
        //public IEnumerable<Guid> Files { get; set; }

        public string Files { get; set; } // todo template - temp fix to hook up everything.
    }

    public class RecentMediaViewModel
    {
        public ConcertViewModel Concert { get; set; }

        public MediaViewModel Media { get; set; }

        public ArtistViewModel Artist { get; set; }
    }

    public class FileViewModel
    {
        public Guid Id { get; set; }

        public string Url { get; set; }
    }

    public class FileHandlerViewModel
    {
        public string Date { get; set; }
    }
}