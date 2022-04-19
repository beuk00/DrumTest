using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrumLib.Models
{
    public class HiHatController : BaseModel
    {
        public IEnumerable<DrumKit> DrumKits { get; set; }

        public string FileLocation { get; set; }
    }
}
