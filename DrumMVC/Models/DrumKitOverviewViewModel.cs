using DrumLib.Models;
using System.Collections.Generic;

namespace DrumMVC.Models
{
    public class DrumKitOverviewViewModel
    {
        public IEnumerable<DrumKit> DrumKits { get; set; }
    }
}
