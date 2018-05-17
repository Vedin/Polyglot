using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
namespace PolyglotMy
{



    partial class Form1 : Form
    {
        private void AllReadersLoadVoice()
        {
            ReaderOriginal = new SpeechSynthesizer();
            ReaderTranslate = new SpeechSynthesizer();
            ReaderTranslateOur = new SpeechSynthesizer();
            _settingsEqualizer = SettingsEqualizer.GetSettings();

            try
            {
                ReaderOriginal.SelectVoice(_settingsEqualizer.VoiceNameLeft);
                ReaderTranslate.SelectVoice(_settingsEqualizer.VoiceNameRight);
                ReaderTranslateOur.SelectVoice(_settingsEqualizer.VoiceNameMid);

            }
            catch (Exception ex)
            {
                ReaderOriginal.SelectVoice(Globals.SpeechSentizerVoice);
                ReaderTranslate.SelectVoice(Globals.SpeechSentizerVoice);
                ReaderTranslateOur.SelectVoice(Globals.SpeechSentizerVoice);
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AllReadersLoadSettings()
        {
            try
            {
                AllReadersLoadVolume();
                AllReadersLoadRate();
            }
            catch (Exception ex)
            {
                AllReadersLoadVolume(true);
                AllReadersLoadRate(true);
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AllReadersLoadVolume(bool isDefault = false)
        {
            if (!isDefault)
            {
                ReaderOriginal.Volume = _settingsEqualizer.Volume;
                ReaderTranslate.Volume = _settingsEqualizer.Volume;
                ReaderTranslateOur.Volume = _settingsEqualizer.Volume;
            }
            else
            {
                ReaderOriginal.Volume = Globals.EqulizerVolumeDefault;
                ReaderTranslate.Volume = Globals.EqulizerVolumeDefault;
                ReaderTranslateOur.Volume = Globals.EqulizerVolumeDefault;
            }
        }

        private void AllReadersLoadRate(bool isDefault = false)
        {
            if (!isDefault)
            {
                ReaderOriginal.Rate = _settingsEqualizer.Speed;
                ReaderTranslate.Rate = _settingsEqualizer.Speed;
                ReaderTranslateOur.Rate = _settingsEqualizer.Speed;
            }
            else
            {
                ReaderOriginal.Rate = Globals.EqulizerSpeedDefault;
                ReaderTranslate.Rate = Globals.EqulizerSpeedDefault;
                ReaderTranslateOur.Rate = Globals.EqulizerSpeedDefault;
            }
        }
    }
}
