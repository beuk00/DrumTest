using DrumLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
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
using Gma.System.MouseKeyHook.Implementation;

namespace DrumWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfContext context = WpfContext.Instance;
        SoundPlayer snd = null;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = context;
        }

        private void btnCrashCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CrashCymbal crashC = (CrashCymbal)cmbCrashCymbal.SelectedItem;

            if (crashC != null)
            {

             Properties.Resources.CrashCym = crashC.Name;
                snd = new SoundPlayer(Properties.Resources.crashCym);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Crash_Cymbal_1__1_);
            }
            snd.Play();
        }

        private void btnFloorTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FloorTom floorT = (FloorTom)cmbFloorTom.SelectedItem;

            if (floorT != null)
            {
                Properties.Resources.FloorT = floorT.Name;
                snd = new SoundPlayer(Properties.Resources.floorT);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Floor_Tom_1);
            }
            snd.Play();
        }

        private void btnOpenHiHat_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnSnareDrum_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SnareDrum snare = (SnareDrum)cmbSnareDrum.SelectedItem;

            if (snare != null)
            {
                Properties.Resources.Snare = snare.Name;
                snd = new SoundPlayer(Properties.Resources.snare);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Ensoniq_ESQ_1_Snare);
            }
            snd.Play();
        }

        private void btnHiHatController_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HiHatController pedal = (HiHatController)cmbHiHatController.SelectedItem;

            if (pedal != null)
            {
                Properties.Resources.HiHatPedal = pedal.Name;
                snd = new SoundPlayer(Properties.Resources.hiHatPedal);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Pedal_Hi_Hat_1);
            }
            snd.Play();

            if (btnClosedHH.Content.ToString() == "OpenHH")
            {
                btnClosedHH.Content = "ClosedHH";
            }
            else
            {
                btnClosedHH.Content = "OpenHH";
            }
        }

        private void btnClosesHH_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btnClosedHH.Content.ToString() == "ClosedHH")
            {
                ClosedHiHat closed = (ClosedHiHat)cmbClosedHiHat.SelectedItem;

                if (closed != null)
                {
                    Properties.Resources.CHiHat = closed.Name;
                    snd = new SoundPlayer(Properties.Resources.cHiHat);
                }
                else
                {
                    snd = new SoundPlayer(Properties.Resources.Closed_Hi_Hat_1);
                }
                snd.Play();
            }
            else
            {
                OpenHiHat open = (OpenHiHat)cmbOpenHiHat.SelectedItem;

                if (open != null)
                {
                    Properties.Resources.OHiHat = open.Name;
                    snd = new SoundPlayer(Properties.Resources.oHiHat);
                }
                else
                {
                    snd = new SoundPlayer(Properties.Resources.Open_Hi_Hat_1);
                }
                snd.Play();
            }
        }

        private void btnHighTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HighTom highT = (HighTom)cmbHighTom.SelectedItem;

            if (highT != null)
            {
                Properties.Resources.HighT = highT.Name;
                snd = new SoundPlayer(Properties.Resources.highT);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Hi_Tom_1);
            }
            snd.Play();
        }

        private void btnRideCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RideCymbal rideC = (RideCymbal)cmbRideCymbal.SelectedItem;

            if (rideC != null)
            {
                Properties.Resources.RideCym = rideC.Name;
                snd = new SoundPlayer(Properties.Resources.rideCym);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Ensoniq_SQ_1_Ride_Cymbal);
            }
            snd.Play();
        }

        private void btnMidTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MidTom midT = (MidTom)cmbMidTom.SelectedItem;

            if (midT != null)
            {
                Properties.Resources.MidT = midT.Name;
                snd = new SoundPlayer(Properties.Resources.midT);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Mid_Tom_1);
            }
            snd.Play();
        }

        private void btnKick_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Kick bass = (Kick)cmbKick.SelectedItem;

            if (bass != null)
            {
                Properties.Resources.KickD = bass.Name;
                snd = new SoundPlayer(Properties.Resources.kickD);
            }
            else
            {
                snd = new SoundPlayer(Properties.Resources.Electronic_Kick_1);
            }
            snd.Play();
        }

        private void btnSaveKit_Click(object sender, RoutedEventArgs e)
        {
            if (txtSaveKit.Text == "")
            {
                MessageBox.Show("Please enter a name for your Drumkit!");
            }
            else if (MessageBox.Show("Are you sure you want to save DrumKit: " + txtSaveKit.Text + "?",
                    "Save Drumkit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //DrumKit drum = new DrumKit(
                //    txtSaveKit.Text,
                //    context.DrumKits.Count, 
                //    (SnareDrum)cmbSnareDrum.SelectedItem, 
                //    (Kick)cmbKick.SelectedItem, 
                //    (OpenHiHat)cmbOpenHiHat.SelectedItem, 
                //    (ClosedHiHat)cmbClosedHiHat.SelectedItem, 
                //    (HiHatController)cmbHiHatController.SelectedItem, 
                //    (HighTom)cmbHighTom.SelectedItem, 
                //    (MidTom)cmbMidTom.SelectedItem, 
                //    (FloorTom)cmbFloorTom.SelectedItem, 
                //    (CrashCymbal)cmbCrashCymbal.SelectedItem, 
                //    (RideCymbal)cmbRideCymbal.SelectedItem
                //    );

                //context.DrumKits.Add(drum);
                //MessageBox.Show("Drumkit saved!");
            }
        }

        private void btnDeleteKit_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDrumKit.SelectedItem == null)
            {
                MessageBox.Show("Please select a DrumKit!");
            }
            else if (MessageBox.Show("Are you sure you want to delete DrumKit: " + cmbDrumKit.SelectedItem + "?",
                    "Delete DrumKit",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // delete kit   

                MessageBox.Show("Drumkit Deleted!");

            }
        }
    }
}
