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

             = crashC.Name;
                snd = new SoundPlayer(Resources.Crash);
            }
            //else
            //{
            //    snd = new SoundPlayer(Properties.Resources.Hats___Noise);
            //}
            snd.Play();
        }

        private void btnFloorTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnOpenHiHat_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnSnareDrum_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnHiHatController_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnClosesHH_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnHighTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnRideCymbal_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnMidTom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnKick_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnKick_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
