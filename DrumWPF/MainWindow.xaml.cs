using DrumLib.Models;
using Melanchall.DryWetMidi.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace DrumWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfContext context = WpfContext.Instance;

        MusicPlayer mp = null;

        private static IInputDevice _inputDevice;

        readonly List<string> modes = new List<string>() { "Mouse", "Keyboard" };

        int numDevs = 0;

       // default sounds

        public delegate void test(string instrument);

        string RideCymbal = "Ensoniq-SQ-1-Ride-Cymbal";
        string CrashCymbal = "Crash-Cymbal-1 (1)";
        string FloorTom = "Floor-Tom-1";
        string HighTom = "Hi-Tom-1";
        string MidTom = "Mid-Tom-1";
        string SnareDrum = "Ensoniq-ESQ-1-Snare";
        string KickPedal = "Bass-Drum-1";
        string OpenHiHat = "Open-Hi-Hat-1";
        string ClosedHiHat = "Closed-Hi-Hat-1";
        string HiHatPedal = "Pedal-Hi-Hat-1";

        public MainWindow()
        {
            InitializeComponent();

            DataContext = context;

            cmbWhatToUse.ItemsSource = modes;
            
            txtInput.Visibility = Visibility.Hidden;
            gbxLetters.Visibility = Visibility.Hidden;

            numDevs = Melanchall.DryWetMidi.Multimedia.InputDevice.GetAll().Count();
            if (numDevs != 0)
            {
                modes.Add("Drum");
            }

            //DrumKit drumKit = context.DrumKits.First();
            //cmbDrumKit.SelectedIndex = 0;
            //DrumKit kit = (DrumKit)cmbDrumKit.SelectedItem;

            // default combobox values

            cmbCrashCymbal.SelectedIndex = 0;
            cmbFloorTom.SelectedIndex = 0;
            cmbHighTom.SelectedIndex = 0;
            cmbClosedHiHat.SelectedIndex = 0;
            cmbHiHatController.SelectedIndex = 0;
            cmbOpenHiHat.SelectedIndex = 0;
            cmbKick.SelectedIndex = 0;
            cmbMidTom.SelectedIndex = 0;
            cmbRideCymbal.SelectedIndex = 0;
            cmbSnareDrum.SelectedIndex = 0;
            cmbDrumKit.SelectedIndex = 0;
            cmbWhatToUse.SelectedItem = modes[0];
        }

        


        // Drum Buttons

        private void btnCrashCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("a");
        }

        private void btnFloorTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("b");
        }

        private void btnSnareDrum_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("c");
        }

        private void btnHiHatController_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("d");
        }

        private void btnClosesHH_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("e");
        }

        private void btnHighTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("f");
        }

        private void btnRideCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("g");
        }

        private void btnMidTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("h");
        }

        private void btnKick_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayInstrument("i");
        }


        // Function Buttons

        private void btnSaveKit_Click(object sender, RoutedEventArgs e)
        {
            if (txtSaveKit.Text == string.Empty)
            {
                MessageBox.Show("Please enter a name for your Drumkit!");
            }
            else if (cmbClosedHiHat.SelectedItem == null ||
                cmbCrashCymbal.SelectedItem == null ||
                cmbFloorTom.SelectedItem == null ||
                cmbHighTom.SelectedItem == null ||
                cmbHiHatController.SelectedItem == null ||
                cmbKick.SelectedItem == null ||
                cmbMidTom.SelectedItem == null ||
                cmbOpenHiHat.SelectedItem == null ||
                cmbRideCymbal.SelectedItem == null ||
                cmbSnareDrum.SelectedItem == null)
            {
                MessageBox.Show("Please select all parts !");
            }
            else if (MessageBox.Show($"Are you sure you want to save DrumKit: {txtSaveKit.Text} ?",
                    "Save Drumkit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DrumKit drum = new DrumKit(
                    txtSaveKit.Text,
                    context.DrumKits.Count,
                    ((SnareDrum)cmbSnareDrum.SelectedItem).Id,
                    ((Kick)cmbKick.SelectedItem).Id,
                    ((OpenHiHat)cmbOpenHiHat.SelectedItem).Id,
                    ((ClosedHiHat)cmbClosedHiHat.SelectedItem).Id,
                    ((HiHatController)cmbHiHatController.SelectedItem).Id,
                    ((HighTom)cmbHighTom.SelectedItem).Id,
                    ((MidTom)cmbMidTom.SelectedItem).Id,
                    ((FloorTom)cmbFloorTom.SelectedItem).Id,
                    ((CrashCymbal)cmbCrashCymbal.SelectedItem).Id,
                    ((RideCymbal)cmbRideCymbal.SelectedItem).Id
                    );

                context.DrumKits.Add(drum);
                MessageBox.Show("Drumkit saved!");
            }
        }

        private void btnDeleteKit_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDrumKit.SelectedItem == null)
            {
                MessageBox.Show("Please select a DrumKit!");
            }
            else if (MessageBox.Show($"Are you sure you want to delete DrumKit: {((DrumKit)cmbDrumKit.SelectedItem).Name} ?",
                    "Delete DrumKit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                context.DrumKits.Remove((DrumKit)cmbDrumKit.SelectedItem);  

                MessageBox.Show("Drumkit Deleted!");
            }
        }


        // Keyboard Keys

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txtInput.Text.ToLower();

            PlayInstrument(input);

            txtInput.Clear();
        }

        public void PlayInstrument(string inp)
        {
            switch (inp)
            {
                case "a":
                    if (CrashCymbal != null)
                    {

                        Properties.Resources.CrashCym = CrashCymbal;

                        mp = new MusicPlayer(Properties.Resources.crashCym.ToString());
                        mp.Play("Crash", CrashCymbal, true);
                    }
                    break;

                case "b":
                    if (FloorTom != null)
                    {
                        Properties.Resources.FloorT = FloorTom;

                        mp = new MusicPlayer(Properties.Resources.floorT.ToString());
                        mp.Play("FloorTom", FloorTom, true);
                    }
                    break;

                case "c":
                    if (SnareDrum != null)
                    {
                        Properties.Resources.Snare = SnareDrum;

                        mp = new MusicPlayer(Properties.Resources.snare.ToString());
                        mp.Play("Snare", SnareDrum, true);
                    }
                    break;

                case "d":
                    if (HiHatPedal != null)
                    {
                        Properties.Resources.HiHatPedal = HiHatPedal;

                        mp = new MusicPlayer(Properties.Resources.hiHatPedal.ToString());
                        mp.Play("HiHat controller", HiHatPedal, true);
                    }

                    if (btnClosedHH.Content.ToString() == "OpenHH")
                    {
                        btnClosedHH.Content = "ClosedHH";
                    }
                    else
                    {
                        btnClosedHH.Content = "OpenHH";
                    }
                    break;

                case "e":
                    if (btnClosedHH.Content.ToString() == "ClosedHH")
                    {
                        if (ClosedHiHat != null)
                        {
                            Properties.Resources.CHiHat = ClosedHiHat;

                            mp = new MusicPlayer(Properties.Resources.cHiHat.ToString());
                            mp.Play("HiHat closed", ClosedHiHat, true);
                        }
                    }
                    else
                    {
                        if (OpenHiHat != null)
                        {
                            Properties.Resources.OHiHat = OpenHiHat;

                            mp = new MusicPlayer(Properties.Resources.oHiHat.ToString());
                            mp.Play("HiHat open", OpenHiHat, true);
                        }
                    }
                    break;

                case "f":
                    if (HighTom != null)
                    {
                        Properties.Resources.HighT = HighTom;

                        mp = new MusicPlayer(Properties.Resources.highT.ToString());
                        mp.Play("HighTom", HighTom, true);
                    }
                    break;

                case "g":
                    if (RideCymbal != null)
                    {
                        Properties.Resources.RideCym = RideCymbal;

                        mp = new MusicPlayer(Properties.Resources.rideCym.ToString());
                        mp.Play("Ride", RideCymbal, true);
                    }
                    break;

                case "h":
                    if (MidTom != null)
                    {
                        Properties.Resources.MidT = MidTom;

                        mp = new MusicPlayer(Properties.Resources.midT.ToString());
                        mp.Play("MidTom",MidTom, true);
                    }
                    break;

                case "i":
                    if (KickPedal != null)
                    {
                        Properties.Resources.KickD = KickPedal;

                        mp = new MusicPlayer(Properties.Resources.kickD.ToString());
                        mp.Play("Kick", KickPedal, true);
                    }
                    break;

                default: // all other keys
                    break;
            }
        }


        // switch playmode

        public void ActivateMode(string mode)
        {
            switch (mode)
            {
                case "Keyboard":
                    (_inputDevice as IDisposable)?.Dispose();
                    gbxButtons.IsEnabled = false;
                    txtInput.Visibility = Visibility.Visible;
                    gbxLetters.Visibility = Visibility.Visible;
                    txtInput.Focus();
                    break;

                case "Drum":
                    _inputDevice = Melanchall.DryWetMidi.Multimedia.InputDevice.GetAll().ElementAt(0);
                    _inputDevice.EventReceived += OnEventReceived;
                    _inputDevice.StartEventsListening();

                    lblDrumInfo.Content = Melanchall.DryWetMidi.Multimedia.InputDevice.GetAll().ElementAt(0).Name;
                    gbxButtons.IsEnabled = false;
                    txtInput.Visibility = Visibility.Hidden;
                    gbxLetters.Visibility = Visibility.Hidden;
                    break;

                default: // case "mouse"
                    (_inputDevice as IDisposable)?.Dispose();
                    gbxButtons.IsEnabled = true;
                    txtInput.Visibility = Visibility.Hidden;
                    gbxLetters.Visibility = Visibility.Hidden;
                    break;
            }
        }

        // recive DrumStrokes

        private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        {
            var midiDevice = (Melanchall.DryWetMidi.Multimedia.MidiDevice)sender;
            if (e.Event.EventType != Melanchall.DryWetMidi.Core.MidiEventType.TimingClock)
            {
                //Console.WriteLine($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");

                switch (e.Event.ToString().Substring(e.Event.ToString().IndexOf("(") + 1, e.Event.ToString().IndexOf(",") - e.Event.ToString().IndexOf("(") - 1))
                {
                    case "51": // RideCymbal
                        test g = PlayInstrument;
                        g.Invoke("g");
                        break;

                    case "49": // CrashCymbal
                        test a = PlayInstrument;
                        a.Invoke("a");
                        break;

                    case "42": // ClosedHiHat
                    case "46": // OpenHiHat
                        test ee = PlayInstrument;
                        ee.Invoke("e");
                        break;

                    case "44": // HiHatController
                        test d = PlayInstrument;
                        d.Invoke("d");
                        break;

                    case "48": // HighTom
                        test f = PlayInstrument;
                        f.Invoke("f");
                        break;

                    case "45": // MidTom
                        test h = PlayInstrument;
                        h.Invoke("h");
                        break;

                    case "43": // FloorTom
                        test b = PlayInstrument;
                        b.Invoke("b");
                        break;

                    case "38": // SnareDrum
                        test c = PlayInstrument;
                        c.Invoke("c");
                        break;

                    case "35": // Kick
                        test i  = PlayInstrument;
                        i.Invoke("i");
                        break;

                    default:
                        break;
                }
                
            }
            
        }
        
        // change item comboboxen

        private void cmbWhatToUse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivateMode(cmbWhatToUse.SelectedItem.ToString());
        }

        private void cmbCrashCymbal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CrashCymbal = ((CrashCymbal)cmbCrashCymbal.SelectedItem).Name;
        }

        private void cmbRideCymbal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RideCymbal = ((RideCymbal)cmbRideCymbal.SelectedItem).Name;
        }

        private void cmbClosedHiHat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClosedHiHat = ((ClosedHiHat)cmbClosedHiHat.SelectedItem).Name;
        }

        private void cmbFloorTom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FloorTom = ((FloorTom)cmbFloorTom.SelectedItem).Name;
        }

        private void cmbOpenHiHat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OpenHiHat = ((OpenHiHat)cmbOpenHiHat.SelectedItem).Name;
        }

        private void cmbSnareDrum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SnareDrum = ((SnareDrum)cmbSnareDrum.SelectedItem).Name;
        }

        private void cmbHiHatController_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HiHatPedal = ((HiHatController)cmbHiHatController.SelectedItem).Name;
        }

        private void cmbMidTom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MidTom = ((MidTom)cmbMidTom.SelectedItem).Name;
        }

        private void cmbKick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KickPedal = ((Kick)cmbKick.SelectedItem).Name;
        }

        private void cmbHighTom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HighTom = ((HighTom)cmbHighTom.SelectedItem).Name;
        }

        private void cmbDrumKit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrumKit Kit = (DrumKit)cmbDrumKit.SelectedItem;
        }

        public void SetDrumKit(DrumKit kit)
        {
            ClosedHiHat = kit.ClosedHiHat.Name;
            OpenHiHat = kit.OpenHiHat.Name;
            RideCymbal = kit.RideCymbal.Name;
            SnareDrum = kit.SnareDrum.Name;
            MidTom = kit.MidTom.Name;
            RideCymbal = kit.RideCymbal.Name;
            HighTom = kit.HighTom.Name;
            FloorTom = kit.FloorTom.Name;
            KickPedal = kit.Kick.Name;
            HiHatPedal = kit.HiHatController.Name;
        }
    }
}
