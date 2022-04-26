using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrumLib.Models
{
    public class MidTom : BaseModel
    {
        public IEnumerable<DrumKit> DrumKits { get; set; }

    }
}
