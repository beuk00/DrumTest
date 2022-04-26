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
            };

            var openHiHats = new OpenHiHat[]
            {
                new OpenHiHat { Id = 1, Name = "Open-Hi-Hat-1" },
            };

            var crashCymbals = new CrashCymbal[]
            {
                new CrashCymbal { Id = 1, Name = "Crash-Cymbal-1 (1)"},
            };

            var floorToms = new FloorTom[]
            {
                new FloorTom { Id = 1, Name = "Floor-Tom-1" },
            };

            var highToms = new HighTom[]
            {
                new HighTom { Id = 1, Name = "Hi-Tom-1" },
            };

            var hiHatControllers = new HiHatController[]
            {
                new HiHatController { Id = 1, Name = "Pedal-Hi-Hat-1"  },
            };

            var kicks = new Kick[]
            {
                new Kick { Id = 1, Name = "Bass-Drum-1" },
            };

            var midToms = new MidTom[]
            {
                new MidTom { Id = 1, Name = "Mid-Tom-1" },
            };

            var rideCymbals = new RideCymbal[]
            {
                new RideCymbal { Id = 1, Name = "Ensoniq-SQ-1-Ride-Cymbal" },
            };

            var snareDrums = new SnareDrum[]
            {
                new SnareDrum { Id = 1, Name = "Ensoniq-ESQ-1-Snare" },
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
