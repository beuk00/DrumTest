using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static DrumWPF.NativeMethods;

namespace DrumWPF
{
    public class InputPort
    {
        private NativeMethods.MidiInProc midiInProc;
        private IntPtr handle;

        public InputPort()
        {
            midiInProc = new NativeMethods.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int InputCount
        {
            get { return NativeMethods.midiInGetNumDevs(); }
        }

        public bool Close()
        {
            bool result = NativeMethods.midiInClose(handle)
                == NativeMethods.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return NativeMethods.midiInOpen(
                out handle,
                id,
                midiInProc,
                IntPtr.Zero,
                NativeMethods.CALLBACK_FUNCTION)
                    == NativeMethods.MMSYSERR_NOERROR;
        }

        public bool Start()
        {
            return NativeMethods.midiInStart(handle)
                == NativeMethods.MMSYSERR_NOERROR;
        }

        public bool Stop()
        {
            return NativeMethods.midiInStop(handle)
                == NativeMethods.MMSYSERR_NOERROR;
        }

        private void MidiProc(IntPtr hMidiIn,
            int wMsg,
            IntPtr dwInstance,
            int dwParam1,
            int dwParam2)
        {
            // Receive messages here
        }
    }

    public static class NativeMethods
    {
        internal const int MMSYSERR_NOERROR = 0;
        internal const int CALLBACK_FUNCTION = 0x00030000;

        internal delegate void MidiInProc(
            IntPtr hMidiIn,
            int wMsg,
            IntPtr dwInstance,
            int dwParam1,
            int dwParam2);

        [DllImport("winmm.dll")]
        public static extern int midiInGetNumDevs();

        [DllImport("winmm.dll")]
        internal static extern int midiInClose(
            IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int midiInOpen(
            out IntPtr lphMidiIn,
            int uDeviceID,
            MidiInProc dwCallback,
            IntPtr dwCallbackInstance,
            int dwFlags);

        [DllImport("winmm.dll")]
        internal static extern int midiInStart(IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int midiInStop(IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int midiInGetDevsCaps();

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command,
        StringBuilder returnValue, int returnLength, IntPtr winHandle);

        public delegate void MidiCallBack(int handle, int msg, int instance, int param1, int param2);

        [StructLayout(LayoutKind.Sequential)]
        public struct MidiInCaps
        {
            public UInt16 wMid;
            public UInt16 wPid;
            public UInt32 vDriverVersion;

            [MarshalAs(UnmanagedType.ByValTStr,
               SizeConst = 32)]
            public String szPname;

            public UInt16 wTechnology;
            public UInt16 wVoices;
            public UInt16 wNotes;
            public UInt16 wChannelMask;
            public UInt32 dwSupport;
        }

    }
}
