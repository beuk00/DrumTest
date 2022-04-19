using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrumLib.Models
{
    public class DrumKit : BaseModel
    {
        public DrumKit()
        {

        }

        public int ClosedHiHatId { get; set; }
        [JsonIgnore]
        public ClosedHiHat ClosedHiHat { get; set; }

        public int OpenHiHatId { get; set; }
        [JsonIgnore]
        public OpenHiHat OpenHiHat { get; set; }

        public int CrashCymbalId { get; set; }
        [JsonIgnore]
        public CrashCymbal CrashCymbal { get; set; }

        public int FloorTomId { get; set; }
        [JsonIgnore]
        public FloorTom FloorTom { get; set; }

        public int HighTomId { get; set; }
        [JsonIgnore]
        public HighTom HighTom { get; set; }

        public int HiHatControllerId { get; set; }
        [JsonIgnore]
        public HiHatController HiHatController { get; set; }

        public int KickId { get; set; }
        [JsonIgnore]
        public Kick Kick { get; set; }

        public int MidTomId { get; set; }
        [JsonIgnore]
        public MidTom MidTom { get; set; }

        public int RideCymbalId { get; set; }
        [JsonIgnore]
        public RideCymbal RideCymbal { get; set; }

        public int SnareDrumId { get; set; }
        [JsonIgnore]
        public SnareDrum SnareDrum { get; set; }

        
    }
}
