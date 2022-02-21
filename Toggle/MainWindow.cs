using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Streams.Effects;
using CSCore.DSP;

namespace Toggle
{
    public partial class MainWindow : Form
    {
        private readonly WasapiCapture soundIn;
        private readonly WasapiOut soundOut;
        private readonly PitchShifter pitchBass = null, pitchMiddle = null, pitchTreble = null;
        private readonly DmoWavesReverbEffect reverbBass = null, reverbMiddle = null, reverbTreble = null;
        //General variables
        private const int SampleRate = 16000;
        private const int GeneralBF = 65, GeneralTF = 7500;
        //PitchEffect variables
        private const int PitchBassBF = 300, PitchBassTF = 700;
        private const int PitchMiddleBF = 1000, PitchMiddleTF = 2000;
        private const int PitchTrebleBF = 2500, PitchTrebleTF = 3500;
        //Reverb variables
        private const int ReverbBassBF = 65, ReverbBassTF = 300;
        private const int ReverbMiddleBF = 700, ReverbMiddleTF = 1100;
        private const int ReverbTrebleBF = 2000, ReverbTrebleTF = 3000;

        public MainWindow()
        {
            InitializeComponent();

            //Initialize WasapiCapture for recording
            soundIn = new WasapiCapture(true, AudioClientShareMode.Shared, 0);
            soundIn.Initialize();

            //Initialize the mixer
            var mixer = new SimpleMixer(2, SampleRate)
            {
                FillWithZeros = true,
                DivideResult = true
            };

            //Split the input signal into different frequency ranges, apply pitch and add to the mixer
            if (GeneralBF != PitchBassBF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, GeneralBF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, PitchBassBF);

                mixer.AddSource(nonEffectSource);
            }

            if (PitchBassBF != PitchBassTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, PitchBassBF);
                var pitchBassSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                pitchBassSource.Filter = new LowpassFilter(SampleRate, PitchBassTF);

                pitchBass = new PitchShifter(pitchBassSource);
                mixer.AddSource(pitchBass);
            }

            if (PitchBassTF != PitchMiddleBF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, PitchBassTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, PitchMiddleBF);

                mixer.AddSource(nonEffectSource);
            }

            if (PitchMiddleBF != PitchMiddleTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, PitchMiddleBF);
                var pitchMiddleSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                pitchMiddleSource.Filter = new LowpassFilter(SampleRate, PitchMiddleTF);

                pitchMiddle = new PitchShifter(pitchMiddleSource);
                mixer.AddSource(pitchMiddle);
            }

            if (PitchMiddleTF != PitchTrebleBF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, PitchMiddleTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, PitchTrebleBF);

                mixer.AddSource(nonEffectSource);
            }

            if (PitchTrebleBF != PitchTrebleTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, PitchTrebleBF);
                var pitchTrebleSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                pitchTrebleSource.Filter = new LowpassFilter(SampleRate, PitchTrebleTF);

                pitchTreble = new PitchShifter(pitchTrebleSource);
                mixer.AddSource(pitchTreble);
            }

            if (PitchTrebleTF != GeneralTF)
            {
                var source = new SoundInSource(soundIn) { FillWithZeros = true }
                    .ChangeSampleRate(SampleRate).ToStereo().ToSampleSource();

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, PitchTrebleTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, GeneralTF);

                mixer.AddSource(nonEffectSource);
            }
            /*
            //Split the mixer signal into different frequency ranges, apply reverb and add to another mixer
            if (GeneralBF != ReverbBassBF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, GeneralBF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, ReverbBassBF);

                mixer.AddSource(nonEffectSource);
            }

            if (ReverbBassBF != ReverbBassTF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbBassBF);
                var reverbBassSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                reverbBassSource.Filter = new LowpassFilter(SampleRate, ReverbBassTF);

                reverbBass = new DmoWavesReverbEffect(reverbBassSource.ToWaveSource());
                mixer.AddSource(reverbBass.ToSampleSource());
            }

            if (ReverbBassTF != ReverbMiddleBF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbBassTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, ReverbMiddleBF);

                mixer.AddSource(nonEffectSource);
            }

            if (ReverbMiddleBF != ReverbMiddleTF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbMiddleBF);
                var reverbMiddleSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                reverbMiddleSource.Filter = new LowpassFilter(SampleRate, ReverbMiddleTF);

                reverbMiddle = new DmoWavesReverbEffect(reverbMiddleSource.ToWaveSource());
                mixer.AddSource(reverbMiddle.ToSampleSource());
            }

            if (ReverbMiddleTF != ReverbTrebleBF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbMiddleTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, ReverbTrebleBF);

                mixer.AddSource(nonEffectSource);
            }

            if (ReverbTrebleBF != ReverbTrebleTF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbTrebleBF);
                var reverbTrebleSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                reverbTrebleSource.Filter = new LowpassFilter(SampleRate, ReverbTrebleTF);

                reverbTreble = new DmoWavesReverbEffect(reverbTrebleSource.ToWaveSource());
                mixer.AddSource(reverbTreble.ToSampleSource());
            }

            if (ReverbTrebleTF != GeneralTF)
            {
                var source = new SimpleMixer(2, SampleRate);
                source.AddSource(mixer);

                var tempFilter = source.AppendSource(x => new BiQuadFilterSource(x));
                tempFilter.Filter = new HighpassFilter(SampleRate, ReverbTrebleTF);
                var nonEffectSource = tempFilter.AppendSource(x => new BiQuadFilterSource(x));
                nonEffectSource.Filter = new LowpassFilter(SampleRate, GeneralTF);

                mixer.AddSource(nonEffectSource);
            }
            */
            //Initialize the soundout with the final mixer 
            soundOut = new WasapiOut() { Latency = 100 };
            soundOut.Initialize(mixer.ToWaveSource());
        }
        
        private void Bass_Scroll(object sender, EventArgs e)
        {
            if (pitchBass != null)
            {
                float value = (float) BassTrackBar.Value / 10;
                pitchBass.PitchShiftFactor = value;
                BassPitchIntencity.Text = value.ToString();
            }
                
        }

        private void Middle_Scroll(object sender, EventArgs e)
        {
            if (pitchMiddle != null)
            {
                float value = (float) MiddleTrackBar.Value / 10;
                pitchMiddle.PitchShiftFactor = (float)MiddleTrackBar.Value / 10;
                MiddlePitchIntencity.Text = value.ToString();
            }
        }

        private void Treble_Scroll(object sender, EventArgs e)
        {
            if (pitchTreble != null)
            {
                float value = (float) TrebleTrackBar.Value / 10;
                pitchTreble.PitchShiftFactor = (float)TrebleTrackBar.Value / 10;
                TreblePitchIntencity.Text = value.ToString();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            soundOut.Dispose();
            soundIn.Dispose();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            soundIn.Start();
            soundOut.Play();
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            soundIn.Stop();
            soundOut.Stop();
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
        }
    }
}