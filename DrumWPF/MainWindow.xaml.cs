using DrumLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrumWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfContext context = WpfContext.Instance;
        MusicPlayer mp = null;
        SoundPlayer snd = null;
        List<string> modes = new List<string>() { "Mouse", "Keyboard", "Drum" };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = context;
            cmbWhatToUse.ItemsSource = modes;
            txtInput.Visibility = Visibility.Hidden;
            gbxLetters.Visibility = Visibility.Hidden;
            cmbWhatToUse.SelectedItem = modes[0];

            // default combobox value
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

        }

        private void btnCrashCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CrashCymbal crashC = (CrashCymbal)cmbCrashCymbal.SelectedItem;

            if (crashC != null)
            {

                Properties.Resources.CrashCym = crashC.Name;
                mp = new MusicPlayer(Properties.Resources.crashCym.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Crash_Cymbal_1__1_.ToString());
            }
            mp.Play("Crash", crashC.Name, true);
        }

        private void btnFloorTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FloorTom floorT = (FloorTom)cmbFloorTom.SelectedItem;

            if (floorT != null)
            {
                Properties.Resources.FloorT = floorT.Name;
                mp = new MusicPlayer(Properties.Resources.floorT.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Floor_Tom_1.ToString());
            }
            mp.Play("FloorTom", floorT.Name, true);
        }

        private void btnSnareDrum_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SnareDrum snare = (SnareDrum)cmbSnareDrum.SelectedItem;

            if (snare != null)
            {
                Properties.Resources.Snare = snare.Name;
                mp = new MusicPlayer(Properties.Resources.snare.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Ensoniq_ESQ_1_Snare.ToString());
            }
            mp.Play("Snare",snare.Name, true);
        }

        private void btnHiHatController_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HiHatController pedal = (HiHatController)cmbHiHatController.SelectedItem;

            if (pedal != null)
            {
                Properties.Resources.HiHatPedal = pedal.Name;
                mp = new MusicPlayer(Properties.Resources.hiHatPedal.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Pedal_Hi_Hat_1.ToString());
            }
            

            if (btnClosedHH.Content.ToString() == "OpenHH")
            {
                btnClosedHH.Content = "ClosedHH";
            }
            else
            {
                btnClosedHH.Content = "OpenHH";
            }

            mp.Play("HiHat controller", pedal.Name, true);
        }

        private void btnClosesHH_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnClosedHH.Content.ToString() == "ClosedHH")
            {
                ClosedHiHat closed = (ClosedHiHat)cmbClosedHiHat.SelectedItem;

                if (closed != null)
                {
                    Properties.Resources.CHiHat = closed.Name;
                    mp = new MusicPlayer(Properties.Resources.cHiHat.ToString());
                }
                else
                {
                    mp = new MusicPlayer(Properties.Resources.Closed_Hi_Hat_1.ToString());
                }
                mp.Play("HiHat closed", closed.Name, true);
            }
            else
            {
                OpenHiHat open = (OpenHiHat)cmbOpenHiHat.SelectedItem;

                if (open != null)
                {
                    Properties.Resources.OHiHat = open.Name;
                    mp = new MusicPlayer(Properties.Resources.oHiHat.ToString());
                }
                else
                {
                    mp = new MusicPlayer(Properties.Resources.Open_Hi_Hat_1.ToString());
                }
                mp.Play("HiHat open", open.Name, true);
            }
        }

        private void btnHighTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HighTom highT = (HighTom)cmbHighTom.SelectedItem;

            if (highT != null)
            {
                Properties.Resources.HighT = highT.Name;
                mp = new MusicPlayer(Properties.Resources.highT.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Hi_Tom_1.ToString());
            }
            mp.Play("HighTom", highT.Name, true);
        }

        private void btnRideCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RideCymbal rideC = (RideCymbal)cmbRideCymbal.SelectedItem;

            if (rideC != null)
            {
                Properties.Resources.RideCym = rideC.Name;
                mp = new MusicPlayer(Properties.Resources.rideCym.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Ensoniq_SQ_1_Ride_Cymbal.ToString());
            }
            mp.Play("Ride", rideC.Name, true);
        }

        private void btnMidTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MidTom midT = (MidTom)cmbMidTom.SelectedItem;

            if (midT != null)
            {
                Properties.Resources.MidT = midT.Name;
                mp = new MusicPlayer(Properties.Resources.midT.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Mid_Tom_1.ToString());
            }
            mp.Play("MidTom", midT.Name, true);
        }

        private void btnKick_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Kick bass = (Kick)cmbKick.SelectedItem;

            if (bass != null)
            {
                Properties.Resources.KickD = bass.Name;
                mp = new MusicPlayer(Properties.Resources.kickD.ToString());
            }
            else
            {
                mp = new MusicPlayer(Properties.Resources.Electronic_Kick_1.ToString());
            }
            mp.Play("Kick", bass.Name, true);
        }

        private void btnSaveKit_Click(object sender, RoutedEventArgs e)
        {
            if (txtSaveKit.Text == "")
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
            else if (MessageBox.Show("Are you sure you want to save DrumKit: " + txtSaveKit.Text + "?",
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
            else if (MessageBox.Show("Are you sure you want to delete DrumKit: " + ((DrumKit)cmbDrumKit.SelectedItem).Name + "?",
                    "Delete DrumKit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                context.DrumKits.Remove((DrumKit)cmbDrumKit.SelectedItem);  

                MessageBox.Show("Drumkit Deleted!");

            }
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = txtInput.Text.ToLower();
            PlayInstrument(input);
            txtInput.Clear();
        }

        public void PlayInstrument(string inp, bool test = false)
        {

            switch (inp)
            {
                case "a":
                    CrashCymbal crashC = (CrashCymbal)cmbCrashCymbal.SelectedItem;

                    if (crashC != null)
                    {

                        Properties.Resources.CrashCym = crashC.Name;
                        mp = new MusicPlayer(Properties.Resources.crashCym.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Crash_Cymbal_1__1_.ToString());
                    }
                    mp.Play("Crash", crashC.Name, true);
                    break;

                case "b":
                    FloorTom floorT = (FloorTom)cmbFloorTom.SelectedItem;

                    if (floorT != null)
                    {
                        Properties.Resources.FloorT = floorT.Name;
                        mp = new MusicPlayer(Properties.Resources.floorT.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Floor_Tom_1.ToString());
                    }
                    mp.Play("FloorTom", floorT.Name, true);
                    break;

                case "c":
                    SnareDrum snare = (SnareDrum)cmbSnareDrum.SelectedItem;

                    if (snare != null)
                    {
                        Properties.Resources.Snare = snare.Name;
                        mp = new MusicPlayer(Properties.Resources.snare.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Ensoniq_ESQ_1_Snare.ToString());
                    }
                    mp.Play("Snare" , snare.Name, true);
                    break;

                case "d":
                    HiHatController pedal = (HiHatController)cmbHiHatController.SelectedItem;

                    if (pedal != null)
                    {
                        Properties.Resources.HiHatPedal = pedal.Name;
                        mp = new MusicPlayer(Properties.Resources.hiHatPedal.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Pedal_Hi_Hat_1.ToString());
                    }
                    mp.Play("HiHat controller", pedal.Name, true);

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
                        ClosedHiHat closed = (ClosedHiHat)cmbClosedHiHat.SelectedItem;

                        if (closed != null)
                        {
                            Properties.Resources.CHiHat = closed.Name;
                            mp = new MusicPlayer(Properties.Resources.cHiHat.ToString());
                        }
                        else
                        {
                            mp = new MusicPlayer(Properties.Resources.Closed_Hi_Hat_1.ToString());
                        }
                        mp.Play("HiHat closed", closed.Name, true);
                    }
                    else
                    {
                        OpenHiHat open = (OpenHiHat)cmbOpenHiHat.SelectedItem;

                        if (open != null)
                        {
                            Properties.Resources.OHiHat = open.Name;
                            mp = new MusicPlayer(Properties.Resources.oHiHat.ToString());
                        }
                        else
                        {
                            mp = new MusicPlayer(Properties.Resources.Open_Hi_Hat_1.ToString());
                        }
                        mp.Play("HiHat open", open.Name, true);
                    }
                    break;

                case "f":
                    HighTom highT = (HighTom)cmbHighTom.SelectedItem;

                    if (highT != null)
                    {
                        Properties.Resources.HighT = highT.Name;
                        mp = new MusicPlayer(Properties.Resources.highT.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Hi_Tom_1.ToString());
                    }
                    mp.Play("HighTom", highT.Name, true);
                    break;

                case "g":
                    RideCymbal rideC = (RideCymbal)cmbRideCymbal.SelectedItem;

                    if (rideC != null)
                    {
                        Properties.Resources.RideCym = rideC.Name;
                        mp = new MusicPlayer(Properties.Resources.rideCym.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Ensoniq_SQ_1_Ride_Cymbal.ToString());
                    }
                    mp.Play("Ride", rideC.Name, true);
                    break;

                case "h":
                    MidTom midT = (MidTom)cmbMidTom.SelectedItem;

                    if (midT != null)
                    {
                        Properties.Resources.MidT = midT.Name;
                        mp = new MusicPlayer(Properties.Resources.midT.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Mid_Tom_1.ToString());
                    }
                    mp.Play("MidTom", midT.Name, true);
                    break;

                case "i":
                    Kick bass = (Kick)cmbKick.SelectedItem;

                    if (bass != null)
                    {
                        Properties.Resources.KickD = bass.Name;
                        mp = new MusicPlayer(Properties.Resources.kickD.ToString());
                    }
                    else
                    {
                        mp = new MusicPlayer(Properties.Resources.Electronic_Kick_1.ToString());
                    }
                    mp.Play("Kick", bass.Name, true);
                    break;


                default:

                    break;
            }

        }

        public void ActivateMode(string mode)
        {
            switch (mode)
            {
                case "Keyboard":
                    txtInput.Visibility = Visibility.Visible;
                    gbxLetters.Visibility = Visibility.Visible;
                    gbxButtons.IsEnabled = false;
                    txtInput.Focus();
                    break;

                case "Drum":
                    gbxButtons.IsEnabled = false;
                    txtInput.Visibility = Visibility.Hidden;
                    gbxLetters.Visibility = Visibility.Hidden;
                    break;

                default:
                    gbxButtons.IsEnabled = true;
                    txtInput.Visibility = Visibility.Hidden;
                    gbxLetters.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void cmbWhatToUse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivateMode(cmbWhatToUse.SelectedItem.ToString());
        }
    }
}
