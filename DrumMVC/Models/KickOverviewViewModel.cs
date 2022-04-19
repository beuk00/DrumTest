using DrumLib.Models;
using System.Collections.Generic;

namespace DrumMVC.Models
{
    public class KickOverviewViewModel
    {
        public IEnumerable<Kick> Kicks { get; set; }
    }
}
