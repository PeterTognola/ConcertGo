using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConcertGo.ViewModels
{
    public class MediaViewModels
    {
    }

    public class MediaViewModel
    {
        public string Comment { get; set; }
    }

    public class CreateMediaViewModel
    {
        [Required]
        public Guid ConcertId { get; set; }

        [Required]
        public string Comment { get; set; }

        public IEnumerable<CreateMediaFileViewModel> Files { get; set; } // todo template...
    }

    public class CreateMediaFileViewModel
    {
        public Guid Id { get; set; }

        public string Location { get; set; }
    }
}