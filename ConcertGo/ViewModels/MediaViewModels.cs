using System;
using System.ComponentModel.DataAnnotations;

namespace ConcertGo.ViewModels
{
    public class MediaViewModels
    {
    }

    public class MediaViewModel
    {
        public string Name { get; set; }
    }

    public class CreateMediaViewModel
    {
        [Required]
        public Guid ConcertId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string FileLocation { get; set; } // todo file type.
    }
}