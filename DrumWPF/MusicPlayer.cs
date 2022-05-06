using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace DrumWPF
{
    public class MusicPlayer
    {

        public bool IsBeingPlayed = false;
        public string FileName;
        public string TrackName;
        private long lngVolume = 500;

        public MusicPlayer(string fileName)
        {
            this.TrackName = fileName;
            if (fileName.Contains("\\"))
                this.FileName = fileName;
            else
                this.FileName = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        private void PlayWorker()
        {
            StringBuilder sb = new StringBuilder();
            mciSendString("open \"" + FileName + "\" type waveaudio  alias " + this.TrackName, sb, 0, IntPtr.Zero);
            mciSendString("play " + this.TrackName, sb, 0, IntPtr.Zero);
            IsBeingPlayed = true;
        }

        #region volume

        //volume between 0-10

        public int GetVolume()
        {
            return (int)this.lngVolume / 100;
        }


        //volume between 0-10

        public void SetVolume(int newvolume)
        {
            this.lngVolume = newvolume * 100;
            //mciSendString("setaudio " + strAlias + " volume to " & lngVolume, "", 0, 0&);
        }

        #endregion

        public void Play(string instrumentType, string instrumentName, bool play)
        {
            FileName = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("DrumWPF") + "DrumWPF".Length)}\\Resources\\{instrumentType}\\{instrumentName}.wav";

            try
            {
                if (IsBeingPlayed)
                    return;
                if (!File.Exists(FileName))
                {
                    IsBeingPlayed = true;
                    return;
                }
                this.IsBeingPlayed = play;
                ThreadStart ts = new ThreadStart(PlayWorker);
                Thread WorkerThread = new Thread(ts);
                WorkerThread.Start();
               
                PlaySound(FileName, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC | SoundFlags.SND_NODEFAULT | SoundFlags.SND_RESOURCE | SoundFlags.SND_NOSTOP | SoundFlags.SND_NOWAIT);
                mciSendString("Open \"" + AppDomain.CurrentDomain.BaseDirectory + "local.wav\" alias local", new StringBuilder(), 0, IntPtr.Zero);
                mciSendString("play local", new StringBuilder(), 0, IntPtr.Zero);
                PlaySound(null, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC | SoundFlags.SND_RESOURCE | SoundFlags.SND_NOSTOP | SoundFlags.SND_NOWAIT);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message);
            }
        }

        public void StopPlaying()
        {
            IsBeingPlayed = false;
        }

        //sound api functions

        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        static extern bool PlaySound(
            string pszSound,
            IntPtr hMod,
            SoundFlags sf);


        // Flags for playing sounds.  

        [Flags]
        public enum SoundFlags : int
        {
            SND_SYNC = 0x0000,  // play synchronously (default) 
            SND_ASYNC = 0x0001,  // play asynchronously 
            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
            SND_MEMORY = 0x0004,  // pszSound points to a memory file
            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
            SND_PURGE = 0x40, // <summary>Stop Playing Wave</summary>
            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
            SND_ALIAS = 0x00010000, // name is a registry alias 
            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
            SND_FILENAME = 0x00020000, // name is file name 
            SND_RESOURCE = 0x00040004  // name is resource name or atom 
        }

    }
}
