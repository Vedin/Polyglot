using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace PolyglotMy
{
    partial class Form1 : Form
    {
        private void AllReadersLoadVoice()
        {
            ReaderOriginal = new SpeechSynthesizer();
            _settingsEqualizer = SettingsEqualizer.GetSettings();

            try
            {
                ReaderOriginal.SelectVoice(_settingsEqualizer.VoiceName);
            }
            catch (Exception ex)
            {
                if (Voices.Count != 0)
                {
                    ReaderOriginal.SelectVoice(Voices[0].Name);
                    MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Exception("None instaled voices");
                }

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
            }
            else
            {
                ReaderOriginal.Volume = Globals.EqulizerVolumeDefault;
            }
        }

        private void AllReadersLoadRate(bool isDefault = false)
        {
            if (!isDefault)
            {
                ReaderOriginal.Rate = _settingsEqualizer.Speed;
            }
            else
            {
                ReaderOriginal.Rate = Globals.EqulizerSpeedDefault;
            }
        }
    }
}
