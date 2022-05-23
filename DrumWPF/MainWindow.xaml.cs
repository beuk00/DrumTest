using DrumLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Windows.Devices.Enumeration;
using Windows.Devices.Midi;
using Windows.Storage.Streams;
using Windows.UI.Core;


namespace DrumWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfContext context = WpfContext.Instance;

        MusicPlayer mp = null;

        //InputPort inputPort = new InputPort();

        readonly List<string> modes = new List<string>() { "Mouse", "Keyboard" };

        int numDevs = 0;

        private List<MidiInPort> midiInPorts;
        MidiDeviceWatcher midiInDeviceWatcher;

        //private static IInputDevice _inputDevice;
       


        public MainWindow()
        {
            InitializeComponent();

            DataContext = context;

            cmbWhatToUse.ItemsSource = modes;

            txtInput.Visibility = Visibility.Hidden;
            gbxLetters.Visibility = Visibility.Hidden;

            numDevs = NativeMethods.midiInGetNumDevs();
            if (numDevs != 0)
            {
                modes.Add("Drum");
            }

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
                    CrashCymbal crashC = (CrashCymbal)cmbCrashCymbal.SelectedItem;

                    if (crashC != null)
                    {

                        Properties.Resources.CrashCym = crashC.Name;

                        mp = new MusicPlayer(Properties.Resources.crashCym.ToString());
                        mp.Play("Crash", crashC.Name, true);
                    }
                    break;

                case "b":
                    FloorTom floorT = (FloorTom)cmbFloorTom.SelectedItem;

                    if (floorT != null)
                    {
                        Properties.Resources.FloorT = floorT.Name;

                        mp = new MusicPlayer(Properties.Resources.floorT.ToString());
                        mp.Play("FloorTom", floorT.Name, true);
                    }
                    break;

                case "c":
                    SnareDrum snare = (SnareDrum)cmbSnareDrum.SelectedItem;

                    if (snare != null)
                    {
                        Properties.Resources.Snare = snare.Name;

                        mp = new MusicPlayer(Properties.Resources.snare.ToString());
                        mp.Play("Snare", snare.Name, true);
                    }
                    break;

                case "d":
                    HiHatController pedal = (HiHatController)cmbHiHatController.SelectedItem;

                    if (pedal != null)
                    {
                        Properties.Resources.HiHatPedal = pedal.Name;

                        mp = new MusicPlayer(Properties.Resources.hiHatPedal.ToString());
                        mp.Play("HiHat controller", pedal.Name, true);
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
                        ClosedHiHat closed = (ClosedHiHat)cmbClosedHiHat.SelectedItem;

                        if (closed != null)
                        {
                            Properties.Resources.CHiHat = closed.Name;

                            mp = new MusicPlayer(Properties.Resources.cHiHat.ToString());
                            mp.Play("HiHat closed", closed.Name, true);
                        }
                    }
                    else
                    {
                        OpenHiHat open = (OpenHiHat)cmbOpenHiHat.SelectedItem;

                        if (open != null)
                        {
                            Properties.Resources.OHiHat = open.Name;

                            mp = new MusicPlayer(Properties.Resources.oHiHat.ToString());
                            mp.Play("HiHat open", open.Name, true);
                        }
                    }
                    break;

                case "f":
                    HighTom highT = (HighTom)cmbHighTom.SelectedItem;

                    if (highT != null)
                    {
                        Properties.Resources.HighT = highT.Name;

                        mp = new MusicPlayer(Properties.Resources.highT.ToString());
                        mp.Play("HighTom", highT.Name, true);
                    }
                    break;

                case "g":
                    RideCymbal rideC = (RideCymbal)cmbRideCymbal.SelectedItem;

                    if (rideC != null)
                    {
                        Properties.Resources.RideCym = rideC.Name;

                        mp = new MusicPlayer(Properties.Resources.rideCym.ToString());
                        mp.Play("Ride", rideC.Name, true);
                    }
                    break;

                case "h":
                    MidTom midT = (MidTom)cmbMidTom.SelectedItem;

                    if (midT != null)
                    {
                        Properties.Resources.MidT = midT.Name;

                        mp = new MusicPlayer(Properties.Resources.midT.ToString());
                        mp.Play("MidTom", midT.Name, true);
                    }
                    break;

                case "i":
                    Kick bass = (Kick)cmbKick.SelectedItem;

                    if (bass != null)
                    {
                        Properties.Resources.KickD = bass.Name;

                        mp = new MusicPlayer(Properties.Resources.kickD.ToString());
                        mp.Play("Kick", bass.Name, true);
                    }
                    break;

                default: // all other keys
                    break;
            }
        }

        public void SelectPlay(object instrument, string namePath, string item)
        {
            var realInstrument = instrument.GetType();

            if (realInstrument != null)
            {
                Properties.Resources.KickD = realInstrument.Name;

                mp = new MusicPlayer(Properties.Resources.kickD.ToString());
                mp.Play(namePath, realInstrument.Name, true);
            }
        }


        // switch playmode

        public void ActivateMode(string mode)
        {
            switch (mode)
            {
                case "Keyboard":
                    //inputPort.Stop();
                    //inputPort.Close();

                    gbxButtons.IsEnabled = false;
                    txtInput.Visibility = Visibility.Visible;
                    gbxLetters.Visibility = Visibility.Visible;
                    txtInput.Focus();
                    break;

                case "Drum":
                    //inputPort.Open(1);
                    //inputPort.Start();

                    //_inputDevice = Melanchall.DryWetMidi.Multimedia.InputDevice.GetByName("Alesis Turbo");
                    //_inputDevice.EventReceived += OnEventReceived;
                    //_inputDevice.StartEventsListening();

                    gbxButtons.IsEnabled = false;
                    txtInput.Visibility = Visibility.Hidden;
                    gbxLetters.Visibility = Visibility.Hidden;
                    break;

                default: // case "mouse"
                    //inputPort.Stop();
                    //inputPort.Close();

                    gbxButtons.IsEnabled = true;
                    txtInput.Visibility = Visibility.Hidden;
                    gbxLetters.Visibility = Visibility.Hidden;
                    break;
            }
        }

        //private static void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
        //{


        //    MidiDevice midiDevice = (MidiDevice)sender;
        //    //if (midiDevice.SilentNoteOnPolicy == MidiEventType.NoteOn)
        //    //{

        //    //}

        //    if (e.Event.EventType == MidiEventType.NoteOn)
        //    {
        //        MessageBox.Show(((NoteOnEvent)e.Event).NoteNumber + " - " + ((NoteOnEvent)e.Event).Velocity);
        //    }
        //    if (e.Event.EventType == MidiEventType.NoteOff)
        //    {
        //        MessageBox.Show(((NoteOffEvent)e.Event).NoteNumber + " - " + ((NoteOffEvent)e.Event).Velocity);
        //    }
        //    //MessageBox.Show($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
        //    MessageBox.Show($"Event received from '{midiDevice.Name}' at {DateTime.Now}: {e.Event}");
        //}

        private void cmbWhatToUse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivateMode(cmbWhatToUse.SelectedItem.ToString());
        }

        private void btnDispose_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ReceiveMIDIMessages()
        {
            this.InitializeComponent();

            // Initialize the list of active MIDI input devices
            this.midiInPorts = new List<MidiInPort>();

            // Set up the MIDI input device watcher
            this.midiInDeviceWatcher = new MidiDeviceWatcher(MidiInPort.GetDeviceSelector(), Dispatcher, inputDevices);

            // Start watching for devices
            this.midiInDeviceWatcher.Start();
        }

        protected /*override*/ void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.OnNavigatedFrom(e);

            // Stop the input device watcher
            this.midiInDeviceWatcher.Stop();

            // Close all MidiInPorts
            foreach (MidiInPort inPort in this.midiInPorts)
            {
                inPort.Dispose();
            }
            this.midiInPorts.Clear();
        }

        private async void inputDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected input MIDI device
            int selectedInputDeviceIndex = /*(sender as ListBox).SelectedIndex*/1 ;

            // Try to create a MidiInPort
            if (selectedInputDeviceIndex < 0)
            {
                // Clear input device messages
                this.inputDeviceMessages.Items.Clear();
                this.inputDeviceMessages.Items.Add("Select a MIDI input device to be able to see its messages");
                this.inputDeviceMessages.IsEnabled = false;
                this.rootPage.NotifyUser("Select a MIDI input device to be able to see its messages", NotifyType.StatusMessage);
                return;
            }

            DeviceInformationCollection devInfoCollection = midiInDeviceWatcher.GetDeviceInformationCollection();
            if (devInfoCollection == null)
            {
                this.inputDeviceMessages.Items.Clear();
                this.inputDeviceMessages.Items.Add("Device not found!");
                this.inputDeviceMessages.IsEnabled = false;
                this.rootPage.NotifyUser("Device not found!", NotifyType.ErrorMessage);
                return;
            }

            DeviceInformation devInfo = devInfoCollection[selectedInputDeviceIndex];
            if (devInfo == null)
            {
                this.inputDeviceMessages.Items.Clear();
                this.inputDeviceMessages.Items.Add("Device not found!");
                this.inputDeviceMessages.IsEnabled = false;
                this.rootPage.NotifyUser("Device not found!", NotifyType.ErrorMessage);
                return;
            }

            var currentMidiInputDevice = await MidiInPort.FromIdAsync(devInfo.Id);
            if (currentMidiInputDevice == null)
            {
                this.rootPage.NotifyUser("Unable to create MidiInPort from input device", NotifyType.ErrorMessage);
                return;
            }

            // We have successfully created a MidiInPort; add the device to the list of active devices, and set up message receiving
            if (!this.midiInPorts.Contains(currentMidiInputDevice))
            {
                this.midiInPorts.Add(currentMidiInputDevice);
                currentMidiInputDevice.MessageReceived += MidiInputDevice_MessageReceived;
            }

            // Clear any previous input messages
            this.inputDeviceMessages.Items.Clear();
            this.inputDeviceMessages.IsEnabled = true;

            this.rootPage.NotifyUser("Input Device selected successfully! Waiting for messages...", NotifyType.StatusMessage);
        }

        /// <summary>
        /// Display the received MIDI message in a readable format
        /// </summary>
        /// <param name="sender">Element that fired the event</param>
        /// <param name="args">The received message</param>
        private async void MidiInputDevice_MessageReceived(MidiInPort sender, MidiMessageReceivedEventArgs args)
        {
            IMidiMessage receivedMidiMessage = args.Message;

            // Build the received MIDI message into a readable format
            StringBuilder outputMessage = new StringBuilder();
            outputMessage.Append(receivedMidiMessage.Timestamp.ToString()).Append(", Type: ").Append(receivedMidiMessage.Type);

            // Add MIDI message parameters to the output, depending on the type of message
            switch (receivedMidiMessage.Type)
            {
                case MidiMessageType.NoteOff:
                    var noteOffMessage = (MidiNoteOffMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(noteOffMessage.Channel).Append(", Note: ").Append(noteOffMessage.Note).Append(", Velocity: ").Append(noteOffMessage.Velocity);
                    break;
                case MidiMessageType.NoteOn:
                    var noteOnMessage = (MidiNoteOnMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(noteOnMessage.Channel).Append(", Note: ").Append(noteOnMessage.Note).Append(", Velocity: ").Append(noteOnMessage.Velocity);
                    break;
                case MidiMessageType.PolyphonicKeyPressure:
                    var polyphonicKeyPressureMessage = (MidiPolyphonicKeyPressureMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(polyphonicKeyPressureMessage.Channel).Append(", Note: ").Append(polyphonicKeyPressureMessage.Note).Append(", Pressure: ").Append(polyphonicKeyPressureMessage.Pressure);
                    break;
                case MidiMessageType.ControlChange:
                    var controlChangeMessage = (MidiControlChangeMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(controlChangeMessage.Channel).Append(", Controller: ").Append(controlChangeMessage.Controller).Append(", Value: ").Append(controlChangeMessage.ControlValue);
                    break;
                case MidiMessageType.ProgramChange:
                    var programChangeMessage = (MidiProgramChangeMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(programChangeMessage.Channel).Append(", Program: ").Append(programChangeMessage.Program);
                    break;
                case MidiMessageType.ChannelPressure:
                    var channelPressureMessage = (MidiChannelPressureMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(channelPressureMessage.Channel).Append(", Pressure: ").Append(channelPressureMessage.Pressure);
                    break;
                case MidiMessageType.PitchBendChange:
                    var pitchBendChangeMessage = (MidiPitchBendChangeMessage)receivedMidiMessage;
                    outputMessage.Append(", Channel: ").Append(pitchBendChangeMessage.Channel).Append(", Bend: ").Append(pitchBendChangeMessage.Bend);
                    break;
                case MidiMessageType.SystemExclusive:
                    var systemExclusiveMessage = (MidiSystemExclusiveMessage)receivedMidiMessage;
                    outputMessage.Append(", ");

                    // Read the SysEx bufffer
                    var sysExDataReader = DataReader.FromBuffer(systemExclusiveMessage.RawData);
                    while (sysExDataReader.UnconsumedBufferLength > 0)
                    {
                        byte byteRead = sysExDataReader.ReadByte();
                        // Pad with leading zero if necessary
                        outputMessage.Append(byteRead.ToString("X2")).Append(" ");
                    }
                    break;
                case MidiMessageType.MidiTimeCode:
                    var timeCodeMessage = (MidiTimeCodeMessage)receivedMidiMessage;
                    outputMessage.Append(", FrameType: ").Append(timeCodeMessage.FrameType).Append(", Values: ").Append(timeCodeMessage.Values);
                    break;
                case MidiMessageType.SongPositionPointer:
                    var songPositionPointerMessage = (MidiSongPositionPointerMessage)receivedMidiMessage;
                    outputMessage.Append(", Beats: ").Append(songPositionPointerMessage.Beats);
                    break;
                case MidiMessageType.SongSelect:
                    var songSelectMessage = (MidiSongSelectMessage)receivedMidiMessage;
                    outputMessage.Append(", Song: ").Append(songSelectMessage.Song);
                    break;
                case MidiMessageType.TuneRequest:
                    var tuneRequestMessage = (MidiTuneRequestMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.TimingClock:
                    var timingClockMessage = (MidiTimingClockMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.Start:
                    var startMessage = (MidiStartMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.Continue:
                    var continueMessage = (MidiContinueMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.Stop:
                    var stopMessage = (MidiStopMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.ActiveSensing:
                    var activeSensingMessage = (MidiActiveSensingMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.SystemReset:
                    var systemResetMessage = (MidiSystemResetMessage)receivedMidiMessage;
                    break;
                case MidiMessageType.None:
                    throw new InvalidOperationException();
                default:
                    break;
            }
        }

            public enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };

        //// Use the Dispatcher to update the messages on the UI thread
        //await Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
        //{
        //    // Skip TimingClock and ActiveSensing messages to avoid overcrowding the list. Commment this check out to see all messages
        //    if ((receivedMidiMessage.Type != MidiMessageType.TimingClock) && (receivedMidiMessage.Type != MidiMessageType.ActiveSensing))
        //    {
        //        this.inputDeviceMessages.Items.Add(outputMessage + "\n");
        //        this.inputDeviceMessages.ScrollIntoView(this.inputDeviceMessages.Items[this.inputDeviceMessages.Items.Count - 1]);
        //        this.rootPage.NotifyUser("Message received successfully!", NotifyType.StatusMessage);
        //    }
        //});
    }
    }
}
