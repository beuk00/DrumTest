﻿// <auto-generated />
using DrumAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrumAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrumLib.Models.ClosedHiHat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClosedHiHats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Closed-Hi-Hat-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Closed-Hi-Hat-2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Closed-Hi-Hat-3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Closed-Hi-Hat-4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Closed-Hi-Hat-5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Closed-Hi-Hat-7"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ensoniq-SQ-1-Closed-Hi-Hat"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.CrashCymbal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CrashCymbals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Crash-Cymbal-1 (1)"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Crash-Cymbal-2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Crash-Cymbal-3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Crash-Cymbal-4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Crash-Cymbal-6"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Crash-Cymbal-7"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Crash-Cymbal-8"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Crash-Cymbal-9"
                        },
                        new
                        {
                            Id = 9,
                            Name = "E-Mu-Proteus-FX-Wacky-Crash-Cymbal"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Ensoniq-SQ-1-Crash-Cymbal"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.DrumKit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClosedHiHatId")
                        .HasColumnType("int");

                    b.Property<int>("CrashCymbalId")
                        .HasColumnType("int");

                    b.Property<int>("FloorTomId")
                        .HasColumnType("int");

                    b.Property<int>("HiHatControllerId")
                        .HasColumnType("int");

                    b.Property<int>("HighTomId")
                        .HasColumnType("int");

                    b.Property<int>("KickId")
                        .HasColumnType("int");

                    b.Property<int>("MidTomId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpenHiHatId")
                        .HasColumnType("int");

                    b.Property<int>("RideCymbalId")
                        .HasColumnType("int");

                    b.Property<int>("SnareDrumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClosedHiHatId");

                    b.HasIndex("CrashCymbalId");

                    b.HasIndex("FloorTomId");

                    b.HasIndex("HiHatControllerId");

                    b.HasIndex("HighTomId");

                    b.HasIndex("KickId");

                    b.HasIndex("MidTomId");

                    b.HasIndex("OpenHiHatId");

                    b.HasIndex("RideCymbalId");

                    b.HasIndex("SnareDrumId");

                    b.ToTable("DrumKits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClosedHiHatId = 1,
                            CrashCymbalId = 1,
                            FloorTomId = 1,
                            HiHatControllerId = 1,
                            HighTomId = 1,
                            KickId = 1,
                            MidTomId = 1,
                            Name = "Standard",
                            OpenHiHatId = 1,
                            RideCymbalId = 1,
                            SnareDrumId = 1
                        });
                });

            modelBuilder.Entity("DrumLib.Models.FloorTom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FloorToms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Floor-Tom-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ensoniq-ESQ-1-Low-Synth-Tom"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Floor-Tom-2"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Floor-Tom-3"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Floor-Tom-4"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Low-Tom-1"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Low-Tom-2"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Low-Tom-3"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Low-Tom-4"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Low-Tom-5"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Tight-Floor-Tom"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Tight-Low-Tom"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.HiHatController", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HiHatsControllers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pedal-Hi-Hat-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Roland-R-8-Pedal-Hi-Hat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Roland-SC-88-Pedal-Hi-Hat"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Yamaha-RM50-Pedal-Hi-Hat-1"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Yamaha-RM50-Pedal-Hi-Hat-2"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.HighTom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HighToms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hi-Tom-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Electro-Tom"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Electronic-Tom-1"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Electronic-Tom-2"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Electronic-Tom-3"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Electronic-Tom-4"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Ensoniq-ESQ-1-Hi-Synth-Tom"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Hi-Tom-2"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Hi-Tom-3"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Hi-Tom-4"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Tight-High-Tom"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.Kick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kicks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bass-Drum-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bass-Drum-2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Bass-Drum-3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Boom-Kick"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Deep-Kick"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dry-Kick"
                        },
                        new
                        {
                            Id = 7,
                            Name = "E-Mu-Proteus-FX-Wacky-Kick"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Electronic-Kick-1"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Electronic-Kick-2"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Electronic-Kick-3"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Ensoniq-SQ-1-Rock-Kick"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Ensoniq-SQ-80-Kick"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Ensoniq-VFX-SD-Kick"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Industrial-Kick-1"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.MidTom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MidToms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mid-Tom-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ensoniq-ESQ-1-Hi-Mid-Synth-Tom"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ensoniq-ESQ-1-Low-Mid-Synth-Tom"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mid-Tom-2"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mid-Tom-3"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mid-Tom-5"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mid-Tom-6"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Tight-Mid-Tom"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.OpenHiHat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OpenHiHats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Open-Hi-Hat-1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ensoniq-SQ-1-Open-Hi-Hat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Open-Hi-Hat-2"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Open-Hi-Hat-4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Open-Hi-Hat-5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Open-Hi-Hat-6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Open-Hi-Hat-7"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.RideCymbal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RideCymbals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ensoniq-SQ-1-Ride-Cymbal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "E-Mu-Proteus-FX-Wacky-Ride-Cymbal"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ensoniq-VFX-SD-Ride-Cymbal"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.SnareDrum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SnareDrums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ensoniq-ESQ-1-Snare"
                        },
                        new
                        {
                            Id = 2,
                            Name = "E-Mu-Proteus-FX-Wacky-Snare"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ensoniq-ESQ-1-Snare-2"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ensoniq-SQ-1-Side-Stick"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ensoniq-VFX-SD-Snare"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hip-Hop-Snare-1"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Noise-Snare-1"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Rim"
                        });
                });

            modelBuilder.Entity("DrumLib.Models.DrumKit", b =>
                {
                    b.HasOne("DrumLib.Models.ClosedHiHat", "ClosedHiHat")
                        .WithMany("DrumKits")
                        .HasForeignKey("ClosedHiHatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.CrashCymbal", "CrashCymbal")
                        .WithMany("DrumKits")
                        .HasForeignKey("CrashCymbalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.FloorTom", "FloorTom")
                        .WithMany("DrumKits")
                        .HasForeignKey("FloorTomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.HiHatController", "HiHatController")
                        .WithMany("DrumKits")
                        .HasForeignKey("HiHatControllerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.HighTom", "HighTom")
                        .WithMany("DrumKits")
                        .HasForeignKey("HighTomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.Kick", "Kick")
                        .WithMany("DrumKits")
                        .HasForeignKey("KickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.MidTom", "MidTom")
                        .WithMany("DrumKits")
                        .HasForeignKey("MidTomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.OpenHiHat", "OpenHiHat")
                        .WithMany("DrumKits")
                        .HasForeignKey("OpenHiHatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.RideCymbal", "RideCymbal")
                        .WithMany("DrumKits")
                        .HasForeignKey("RideCymbalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrumLib.Models.SnareDrum", "SnareDrum")
                        .WithMany("DrumKits")
                        .HasForeignKey("SnareDrumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
