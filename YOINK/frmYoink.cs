using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using NAudio.Wave;
using System.IO;

namespace YOINK
{
    public partial class frmYoink : Form
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys ArrowKeys);

     
        public frmYoink()
        {
           
            InitializeComponent();
        }

        private bool IsBruhhhh()
        {
            try
            {
                var ctrl = GetAsyncKeyState(Keys.LControlKey);
                var C = GetAsyncKeyState(Keys.C);

                return ctrl != 0 && C != 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsYoink()
        {
            try
            {
                var ctrl = GetAsyncKeyState(Keys.LControlKey);
                var v = GetAsyncKeyState(Keys.V);

                return ctrl != 0 && v != 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void frmYoink_Load(object sender, EventArgs e)
        {
            

            while (true)
            {
                if (IsBruhhhh())
                {
                    using (var ms = File.OpenRead("BRUH.mp3"))
                    using (var rdr = new Mp3FileReader(ms))
                    using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
                    using (var baStream = new BlockAlignReductionStream(wavStream))
                    using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(baStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                }

                if (IsYoink())
                {
                    using (var ms = File.OpenRead("YoinkAudio.mp3"))
                    using (var rdr = new Mp3FileReader(ms))
                    using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
                    using (var baStream = new BlockAlignReductionStream(wavStream))
                    using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(baStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                }

                Thread.Sleep(16);
            }
        }
    }
}
