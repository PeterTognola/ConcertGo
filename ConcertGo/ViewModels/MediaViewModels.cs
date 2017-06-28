using System;
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

        //[Required]
        //public IEnumerable<Guid> Files { get; set; }

        public string Files { get; set; } // todo template - temp fix to hook up everything.
    }
}