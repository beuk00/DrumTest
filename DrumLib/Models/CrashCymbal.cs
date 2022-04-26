using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrumLib.Models
{
    public class CrashCymbal : BaseModel
    {
        public IEnumerable<DrumKit> DrumKits { get; set; }

    }
}
