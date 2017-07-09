using System.Collections.Generic;

namespace ConcertGo.ViewModels
{
    public class HomeViewModels
    {
    }

    public class HomeViewModel
    {
        public IEnumerable<RecentMediaViewModel> RecentMedia { get; set; }
    }

    public class RecentMediaViewModel
    {
        public FileViewModel File { get; set; }
    }
}