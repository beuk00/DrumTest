
using DrumLib.Models;
using DrumWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrumWPF
{
    public class WpfContext : INotifyPropertyChanged
    {
        private readonly CrashCymbalRepository _crashCymbalRepository = new CrashCymbalRepository();
        private readonly FloorTomRepository _floorTomRepository = new FloorTomRepository();
        private readonly HighTomRepository _highTomRepository = new HighTomRepository();
        private readonly ClosedHiHatRepository _closedHiHatRepository = new ClosedHiHatRepository();
        private readonly HiHatControllerRepository _hiHatControllerRepository = new HiHatControllerRepository();
        private readonly OpenHiHatRepository _openHiHatRepository = new OpenHiHatRepository();
        private readonly KickRepository _kickRepository = new KickRepository();
        private readonly MidTomRepository _midTomRepository = new MidTomRepository();
        private readonly RideCymbalRepository _rideCymbalRepository = new RideCymbalRepository();
        private readonly SnareDrumRepository _snareDrumRepository = new SnareDrumRepository();
        private readonly DrumKitRepository _drumKitRepository = new DrumKitRepository();

        #region props

        private ObservableCollection<CrashCymbal> crashCymbals = new ObservableCollection<CrashCymbal>();
        public ObservableCollection<CrashCymbal> CrashCymbals
        {
            get { return crashCymbals; }
            set
            {
                if (value != crashCymbals)
                {
                    crashCymbals = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<FloorTom> floorToms = new ObservableCollection<FloorTom>();
        public ObservableCollection<FloorTom> FloorToms
        {
            get { return floorToms; }
            set
            {
                if (value != floorToms)
                {
                    floorToms = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<HighTom> highToms = new ObservableCollection<HighTom>();
        public ObservableCollection<HighTom> HighToms
        {
            get { return highToms; }
            set
            {
                if (value != highToms)
                {
                    highToms = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<ClosedHiHat> closedHiHats = new ObservableCollection<ClosedHiHat>();
        public ObservableCollection<ClosedHiHat> ClosedHiHats
        {
            get { return closedHiHats; }
            set
            {
                if (value != closedHiHats)
                {
                    closedHiHats = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<HiHatController> hiHatControllers = new ObservableCollection<HiHatController>();
        public ObservableCollection<HiHatController> HiHatControllers
        {
            get { return hiHatControllers; }
            set
            {
                if (value != hiHatControllers)
                {
                    hiHatControllers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<OpenHiHat> openHiHats = new ObservableCollection<OpenHiHat>();
        public ObservableCollection<OpenHiHat> OpenHiHats
        {
            get { return openHiHats; }
            set
            {
                if (value != openHiHats)
                {
                    openHiHats = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<Kick> kicks = new ObservableCollection<Kick>();
        public ObservableCollection<Kick> Kicks
        {
            get { return kicks; }
            set
            {
                if (value != kicks)
                {
                    kicks = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<MidTom> midToms = new ObservableCollection<MidTom>();
        public ObservableCollection<MidTom> MidToms
        {
            get { return midToms; }
            set
            {
                if (value != midToms)
                {
                    midToms = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<RideCymbal> rideCymbals = new ObservableCollection<RideCymbal>();
        public ObservableCollection<RideCymbal> RideCymbals
        {
            get { return rideCymbals; }
            set
            {
                if (value != rideCymbals)
                {
                    rideCymbals = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<SnareDrum> snareDrums = new ObservableCollection<SnareDrum>();
        public ObservableCollection<SnareDrum> SnareDrums
        {
            get { return snareDrums; }
            set
            {
                if (value != snareDrums)
                {
                    snareDrums = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<DrumKit> drumKits = new ObservableCollection<DrumKit>();
        public ObservableCollection<DrumKit> DrumKits
        {
            get { return drumKits; }
            set
            {
                if (value != drumKits)
                {
                    drumKits = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        private static readonly Lazy<WpfContext> _instance = new Lazy<WpfContext>(() => new WpfContext());

        public static WpfContext Instance
        {
            get { return _instance.Value; }
        }

        private WpfContext()
        {
            CrashCymbals = new ObservableCollection<CrashCymbal>(new List<CrashCymbal>() { new CrashCymbal() { Name = "" } });

            Task.Run(() => LoadCrashCymbals());
            Task.Run(() => LoadFloorToms());
            Task.Run(() => LoadHighToms());
            Task.Run(() => LoadClosedHiHats());
            Task.Run(() => LoadHiHatControllers());
            Task.Run(() => LoadOpenHiHats());
            Task.Run(() => LoadKicks());
            Task.Run(() => LoadMidToms());
            Task.Run(() => LoadRideCymbals());
            Task.Run(() => LoadSnareDrums());
            Task.Run(() => LoadDrumKits());
        }

        private async void LoadCrashCymbals()
        {
            CrashCymbals = new ObservableCollection<CrashCymbal>(await _crashCymbalRepository.ListAll());
        }

        private async void LoadFloorToms()
        {
            FloorToms = new ObservableCollection<FloorTom>(await _floorTomRepository.ListAll());
        }

        private async void LoadHighToms()
        {
            HighToms = new ObservableCollection<HighTom>(await _highTomRepository.ListAll());
        }

        private async void LoadClosedHiHats()
        {
            ClosedHiHats = new ObservableCollection<ClosedHiHat>(await _closedHiHatRepository.ListAll());
        }

        private async void LoadHiHatControllers()
        {
            HiHatControllers = new ObservableCollection<HiHatController>(await _hiHatControllerRepository.ListAll());
        }

        private async void LoadOpenHiHats()
        {
            OpenHiHats = new ObservableCollection<OpenHiHat>(await _openHiHatRepository.ListAll());
        }

        private async void LoadKicks()
        {
            Kicks = new ObservableCollection<Kick>(await _kickRepository.ListAll());
        }

        private async void LoadMidToms()
        {
            MidToms = new ObservableCollection<MidTom>(await _midTomRepository.ListAll());
        }

        private async void LoadRideCymbals()
        {
            RideCymbals = new ObservableCollection<RideCymbal>(await _rideCymbalRepository.ListAll());
        }

        private async void LoadSnareDrums()
        {
            SnareDrums = new ObservableCollection<SnareDrum>(await _snareDrumRepository.ListAll());
        }

        private async void LoadDrumKits()
        {
            DrumKits = new ObservableCollection<DrumKit>(await _drumKitRepository.ListAll());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
