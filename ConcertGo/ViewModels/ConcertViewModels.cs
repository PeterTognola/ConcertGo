using System.Collections.Generic;
using System.ComponentModel;

namespace ConcertGo.ViewModels
{
    public class ConcertViewModels
    {
    }

    public class ConcertDetailViewModel
    {
        [DisplayName("Concert Name")]
        public string ConcertName { get; set; }

        [DisplayName("Artists")]
        public IEnumerable<ArtistViewModel> Artists { get; set; }
    }
}