using DrumLib.Models;
using Microsoft.EntityFrameworkCore;

namespace DrumAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ClosedHiHat> ClosedHiHats { get; set; }
        public DbSet<CrashCymbal> CrashCymbals { get; set; }
        public DbSet<DrumKit> DrumKits { get; set; }
        public DbSet<FloorTom> FloorToms { get; set; }
        public DbSet<HighTom> HighToms { get; set; }
        public DbSet<HiHatController> HiHatsControllers { get; set; }
        public DbSet<Kick> Kicks { get; set; }
        public DbSet<MidTom> MidToms { get; set; }
        public DbSet<OpenHiHat> OpenHiHats { get; set; }
        public DbSet<RideCymbal> RideCymbals { get; set; }
        public DbSet<SnareDrum> SnareDrums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // fluent API

            modelBuilder.Entity<ClosedHiHat>().HasKey(chh => chh.Id);
            modelBuilder.Entity<ClosedHiHat>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<CrashCymbal>().HasKey(cc => cc.Id);
            modelBuilder.Entity<CrashCymbal>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<FloorTom>().HasKey(ft => ft.Id);
            modelBuilder.Entity<FloorTom>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<HighTom>().HasKey(ht => ht.Id);
            modelBuilder.Entity<HighTom>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<HiHatController>().HasKey(hhc => hhc.Id);
            modelBuilder.Entity<HiHatController>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<Kick>().HasKey(k => k.Id);
            modelBuilder.Entity<Kick>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<MidTom>().HasKey(mt => mt.Id);
            modelBuilder.Entity<MidTom>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<OpenHiHat>().HasKey(ohh => ohh.Id);
            modelBuilder.Entity<OpenHiHat>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<RideCymbal>().HasKey(rc => rc.Id);
            modelBuilder.Entity<RideCymbal>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<SnareDrum>().HasKey(sd => sd.Id);
            modelBuilder.Entity<SnareDrum>().Property(n => n.Name).IsRequired();

            modelBuilder.Entity<DrumKit>().HasKey(dk => dk.Id);
            modelBuilder.Entity<DrumKit>().Property(dk => dk.SnareDrumId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.ClosedHiHatId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.OpenHiHatId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.HiHatControllerId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.HighTomId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.MidTomId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.FloorTomId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.CrashCymbalId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.RideCymbalId).IsRequired();
            modelBuilder.Entity<DrumKit>().Property(dk => dk.Name).IsRequired();



            base.OnModelCreating(modelBuilder);

            var closedHiHats = new ClosedHiHat[]
            {
                new ClosedHiHat { Id = 1, Name = "Closed-Hi-Hat-1" },
                new ClosedHiHat { Id = 2, Name = "Closed-Hi-Hat-2" },
                new ClosedHiHat { Id = 3, Name = "Closed-Hi-Hat-3" },
                new ClosedHiHat { Id = 4, Name = "Closed-Hi-Hat-4" },
                new ClosedHiHat { Id = 5, Name = "Closed-Hi-Hat-5" },
                new ClosedHiHat { Id = 6, Name = "Closed-Hi-Hat-7" },
                new ClosedHiHat { Id = 7, Name = "Ensoniq-SQ-1-Closed-Hi-Hat" },
            };

            var openHiHats = new OpenHiHat[]
            {
                new OpenHiHat { Id = 1, Name = "Open-Hi-Hat-1" },
                new OpenHiHat { Id = 2, Name = "Ensoniq-SQ-1-Open-Hi-Hat" },
                new OpenHiHat { Id = 3, Name = "Open-Hi-Hat-2" },
                new OpenHiHat { Id = 4, Name = "Open-Hi-Hat-4" },
                new OpenHiHat { Id = 5, Name = "Open-Hi-Hat-5" },
                new OpenHiHat { Id = 6, Name = "Open-Hi-Hat-6" },
                new OpenHiHat { Id = 7, Name = "Open-Hi-Hat-7" },
            };

            var crashCymbals = new CrashCymbal[]
            {
                new CrashCymbal { Id = 1, Name = "Crash-Cymbal-1 (1)" },
                new CrashCymbal { Id = 2, Name = "Crash-Cymbal-2" },
                new CrashCymbal { Id = 3, Name = "Crash-Cymbal-3" },
                new CrashCymbal { Id = 4, Name = "Crash-Cymbal-4" },
                new CrashCymbal { Id = 5, Name = "Crash-Cymbal-6" },
                new CrashCymbal { Id = 6, Name = "Crash-Cymbal-7" },
                new CrashCymbal { Id = 7, Name = "Crash-Cymbal-8" },
                new CrashCymbal { Id = 8, Name = "Crash-Cymbal-9" },
                new CrashCymbal { Id = 9, Name = "E-Mu-Proteus-FX-Wacky-Crash-Cymbal" },
                new CrashCymbal { Id = 10, Name = "Ensoniq-SQ-1-Crash-Cymbal" },

            };

            var floorToms = new FloorTom[]
            {
                new FloorTom { Id = 1, Name = "Floor-Tom-1" },
                new FloorTom { Id = 2, Name ="Ensoniq-ESQ-1-Low-Synth-Tom" },
                new FloorTom { Id = 3, Name = "Floor-Tom-2" },
                new FloorTom { Id = 4, Name = "Floor-Tom-3" },
                new FloorTom { Id = 5, Name = "Floor-Tom-4" },
                new FloorTom { Id = 6, Name = "Low-Tom-1" },
                new FloorTom { Id = 7, Name = "Low-Tom-2" },
                new FloorTom { Id = 8, Name = "Low-Tom-3" },
                new FloorTom { Id = 9, Name = "Low-Tom-4" },
                new FloorTom { Id = 10, Name = "Low-Tom-5" },
                new FloorTom { Id = 11, Name = "Tight-Floor-Tom" },
                new FloorTom { Id = 12, Name = "Tight-Low-Tom" },

            };

            var highToms = new HighTom[]
            {
                new HighTom { Id = 1, Name = "Hi-Tom-1" },
                new HighTom { Id = 2, Name = "Electro-Tom" },
                new HighTom { Id = 3, Name = "Electronic-Tom-1" },
                new HighTom { Id = 4, Name = "Electronic-Tom-2" },
                new HighTom { Id = 5, Name = "Electronic-Tom-3" },
                new HighTom { Id = 6, Name = "Electronic-Tom-4" },
                new HighTom { Id = 7, Name = "Ensoniq-ESQ-1-Hi-Synth-Tom" },
                new HighTom { Id = 8, Name = "Hi-Tom-2" },
                new HighTom { Id = 9, Name = "Hi-Tom-3" },
                new HighTom { Id = 10, Name = "Hi-Tom-4" },
                new HighTom { Id = 11, Name = "Tight-High-Tom" },

            };

            var hiHatControllers = new HiHatController[]
            {
                new HiHatController { Id = 1, Name = "Pedal-Hi-Hat-1"  },
                new HiHatController { Id = 2, Name = "Roland-R-8-Pedal-Hi-Hat" },
                new HiHatController { Id = 3, Name = "Roland-SC-88-Pedal-Hi-Hat" },
                new HiHatController { Id = 4, Name = "Yamaha-RM50-Pedal-Hi-Hat-1" },
                new HiHatController { Id = 5, Name = "Yamaha-RM50-Pedal-Hi-Hat-2" },

            };

            var kicks = new Kick[]
            {
                new Kick { Id = 1, Name = "Bass-Drum-1" },
                new Kick { Id = 2, Name = "Bass-Drum-2" },
                new Kick { Id = 3, Name = "Bass-Drum-3" },
                new Kick { Id = 4, Name = "Boom-Kick" },
                new Kick { Id = 5, Name = "Deep-Kick" },
                new Kick { Id = 6, Name = "Dry-Kick" },
                new Kick { Id = 7, Name = "E-Mu-Proteus-FX-Wacky-Kick" },
                new Kick { Id = 8, Name = "Electronic-Kick-1" },
                new Kick { Id = 9, Name = "Electronic-Kick-2" },
                new Kick { Id = 10, Name = "Electronic-Kick-3" },
                new Kick { Id = 11, Name = "Ensoniq-SQ-1-Rock-Kick" },
                new Kick { Id = 12, Name = "Ensoniq-SQ-80-Kick" },
                new Kick { Id = 13, Name = "Ensoniq-VFX-SD-Kick" },
                new Kick { Id = 14, Name = "Industrial-Kick-1" },


            };

            var midToms = new MidTom[]
            {
                new MidTom { Id = 1, Name = "Mid-Tom-1" },
                new MidTom { Id = 2, Name= "Ensoniq-ESQ-1-Hi-Mid-Synth-Tom" },
                new MidTom { Id = 3, Name = "Ensoniq-ESQ-1-Low-Mid-Synth-Tom" },
                new MidTom { Id = 4, Name = "Mid-Tom-2" },
                new MidTom { Id = 5, Name = "Mid-Tom-3" },
                new MidTom { Id = 6, Name = "Mid-Tom-5" },
                new MidTom { Id = 7, Name = "Mid-Tom-6" },
                new MidTom { Id = 8, Name = "Tight-Mid-Tom" },

            };

            var rideCymbals = new RideCymbal[]
            {
                new RideCymbal { Id = 1, Name = "Ensoniq-SQ-1-Ride-Cymbal" },
                new RideCymbal { Id = 2, Name = "E-Mu-Proteus-FX-Wacky-Ride-Cymbal" },
                new RideCymbal { Id = 3, Name = "Ensoniq-VFX-SD-Ride-Cymbal" },
            };

            var snareDrums = new SnareDrum[]
            {
                new SnareDrum { Id = 1, Name = "Ensoniq-ESQ-1-Snare" },
                new SnareDrum { Id = 2, Name= "E-Mu-Proteus-FX-Wacky-Snare" },
                new SnareDrum { Id = 3, Name = "Ensoniq-ESQ-1-Snare-2" },
                new SnareDrum { Id = 4, Name = "Ensoniq-SQ-1-Side-Stick" },
                new SnareDrum { Id = 5, Name = "Ensoniq-VFX-SD-Snare" },
                new SnareDrum { Id = 6, Name = "Hip-Hop-Snare-1" },
                new SnareDrum { Id = 7, Name = "Noise-Snare-1" },
                new SnareDrum { Id = 8, Name = "Rim" },

            };

            var drumKits = new DrumKit[]
            {
                new DrumKit
                (

                    "Standard",
                    id : 1,
                    closedHiHatId : 1,
                    openHiHatId : 1,
                    crashCymbalId : 1,
                    floorTomId : 1,
                    highTomId : 1,
                    hiHatControllerId : 1,
                    kickId : 1,
                    midTomId : 1,
                    rideCymbalId : 1,
                    snareDrumId : 1

                )
            };

            modelBuilder.Entity<ClosedHiHat>().HasData(closedHiHats);
            modelBuilder.Entity<OpenHiHat>().HasData(openHiHats);
            modelBuilder.Entity<CrashCymbal>().HasData(crashCymbals);
            modelBuilder.Entity<FloorTom>().HasData(floorToms);
            modelBuilder.Entity<HighTom>().HasData(highToms);
            modelBuilder.Entity<HiHatController>().HasData(hiHatControllers);
            modelBuilder.Entity<Kick>().HasData(kicks);
            modelBuilder.Entity<MidTom>().HasData(midToms);
            modelBuilder.Entity<RideCymbal>().HasData(rideCymbals);
            modelBuilder.Entity<SnareDrum>().HasData(snareDrums);
            modelBuilder.Entity<DrumKit>().HasData(drumKits);
        }
    }
}
