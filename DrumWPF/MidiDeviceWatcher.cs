using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Windows.Devices.Enumeration;
using Windows.UI.Core;

namespace DrumWPF
{
    internal class MidiDeviceWatcher 
    {
        internal DeviceWatcher deviceWatcher = null;
        internal DeviceInformationCollection deviceInformationCollection = null;
        bool enumerationCompleted = false;
        ListBox portList = null;
        string midiSelector = string.Empty;
        CoreDispatcher coreDispatcher = null;

        internal MidiDeviceWatcher(string midiSelectorString, CoreDispatcher dispatcher, ListBox portListBox)
        {
            this.deviceWatcher = DeviceInformation.CreateWatcher(midiSelectorString);
            this.portList = portListBox;
            this.midiSelector = midiSelectorString;
            this.coreDispatcher = dispatcher;

            this.deviceWatcher.Added += DeviceWatcher_Added;
            this.deviceWatcher.Removed += DeviceWatcher_Removed;
            this.deviceWatcher.Updated += DeviceWatcher_Updated;
            this.deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
        }

        ~MidiDeviceWatcher()
        {
            this.deviceWatcher.Added -= DeviceWatcher_Added;
            this.deviceWatcher.Removed -= DeviceWatcher_Removed;
            this.deviceWatcher.Updated -= DeviceWatcher_Updated;
            this.deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
        }

        internal void Start()
        {
            if (this.deviceWatcher.Status != DeviceWatcherStatus.Started)
            {
                this.deviceWatcher.Start();
            }
        }

        internal void Stop()
        {
            if (this.deviceWatcher.Status != DeviceWatcherStatus.Stopped)
            {
                this.deviceWatcher.Stop();
            }
        }

        internal DeviceInformationCollection GetDeviceInformationCollection()
        {
            return this.deviceInformationCollection;
        }

        private async void UpdateDevices()
        {
            // Get a list of all MIDI devices
            this.deviceInformationCollection = await DeviceInformation.FindAllAsync(this.midiSelector);

            // If no devices are found, update the ListBox
            if ((this.deviceInformationCollection == null) || (this.deviceInformationCollection.Count == 0))
            {
                // Start with a clean list
                this.portList.Items.Clear();

                this.portList.Items.Add("No MIDI ports found");
                this.portList.IsEnabled = false;
            }
            // If devices are found, enumerate them and add them to the list
            else
            {
                // Start with a clean list
                this.portList.Items.Clear();

                foreach (var device in deviceInformationCollection)
                {
                    this.portList.Items.Add(device.Name);
                }

                this.portList.IsEnabled = true;
            }
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation args)
        {
            // If all devices have been enumerated
            if (this.enumerationCompleted)
            {
                await coreDispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    // Update the device list
                    UpdateDevices();
                });
            }
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            // If all devices have been enumerated
            if (this.enumerationCompleted)
            {
                await coreDispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    // Update the device list
                    UpdateDevices();
                });
            }
        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            // If all devices have been enumerated
            if (this.enumerationCompleted)
            {
                await coreDispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    // Update the device list
                    UpdateDevices();
                });
            }
        }

        private async void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            this.enumerationCompleted = true;
            await coreDispatcher.RunAsync(CoreDispatcherPriority.High, () =>
            {
                // Update the device list
                UpdateDevices();
            });
        }
    }
}
