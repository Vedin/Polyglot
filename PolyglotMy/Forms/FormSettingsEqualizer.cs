using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Linq;

namespace PolyglotMy
{
    
    public partial class FormSettingsEqualizer : Form
    {
        Form formbefore;
        SettingsEqualizer _settingsequalizer =  null;

        private List<Voice> Voices { get; set; }
        private SpeechSynthesizer Reader = new SpeechSynthesizer();

        #region Form Functions
        public FormSettingsEqualizer()
        {
            InitializeComponent();
            _initControlls();
        }

        public FormSettingsEqualizer(Form formbefore)
        {
            InitializeComponent();
            _initControlls();
            this.formbefore = formbefore;
        }

        private void FormSettingsEqualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formbefore != null) formbefore.Show();
        }

        #endregion

        #region Buttons

        private void buttonOK_Click(object sender, EventArgs e)
        {
            saved_inf();
            this.Close();
        }
        
        private void buttonAplly_Click(object sender, EventArgs e)
        {
            saved_inf();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _initControlls();
        }

        #endregion

        #region InitControls

        private void _initControlls()
        {
            _settingsequalizer = SettingsEqualizer.GetSettings();

            GetInstalVoicesToComboVoices();

            initionSliders();
            initionSpeed();
            initionVolume();       
        }

        private void GetInstalVoicesToComboVoices()
        {
            try
            {
                Voices = new List<Voice>();
                Reader.GetInstalledVoices().ToList().ForEach(v => Voices.Add(new Voice() { Name = v.VoiceInfo.Name, InstalledVoice = v }));
                
                Globals.EqulizerSliderMinValue = 0;
                Globals.EqulizerSliderMaxValue = Voices.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initionSliders()
        {
            //Equlizer
            SliderLeft.Maximum = Globals.EqulizerSliderMaxValue;
            SliderRight.Maximum = Globals.EqulizerSliderMaxValue;
            SliderMid.Maximum = Globals.EqulizerSliderMaxValue;
            SliderLeft.Minimum = Globals.EqulizerSliderMinValue;
            SliderRight.Minimum = Globals.EqulizerSliderMinValue;
            SliderMid.Minimum = Globals.EqulizerSliderMinValue;
            try
            {
                SliderLeft.Value =  IndexOfVoiceInVoices( _settingsequalizer.VoiceNameLeft);
            }
            catch
            {
                SliderLeft.Value = SliderLeft.Minimum;
            }
            try
            {
                SliderRight.Value = IndexOfVoiceInVoices(_settingsequalizer.VoiceNameRight);
            }
            catch
            {
                SliderRight.Value = SliderRight.Minimum;
            }
            try
            {
                SliderMid.Value = IndexOfVoiceInVoices(_settingsequalizer.VoiceNameMid);
            }
            catch
            {
                SliderMid.Value = SliderMid.Minimum;
            }
            
        }

        private void initionVolume()
        {
            //Volume
            trackBarVolume.Maximum = Globals.EqulizerVolumeMaxValue;
            trackBarVolume.Minimum = Globals.EqulizerVolumeMinValue;
            try
            {
                trackBarVolume.Value = _settingsequalizer.Volume;
            }
            catch
            {
                trackBarVolume.Value = trackBarVolume.Minimum;
            }
        }

        private void initionSpeed()
        {
            //Speed
            trackBarSpeed.Maximum = Globals.EqulizerSpeedMaxValue;
            trackBarSpeed.Minimum = Globals.EqulizerSpeedMinValue;
            try
            {
                trackBarSpeed.Value = _settingsequalizer.Speed;
            }
            catch
            {
                trackBarSpeed.Value = trackBarSpeed.Minimum;
            }
        }
        

        
        
        #endregion

        #region Others

        private int IndexOfVoiceInVoices(string VoiceName)
        {
            for(int i = 0; i < Voices.Count;i++)
            {
                if (Voices[i].Name == VoiceName) return i;
            }
            return -1;
        }

        private string ValueOfIndexInVoices(int index)
        {
            if (index < Voices.Count && index >= 0) return Voices[index].Name;
            return Voices[0].Name;
        }

        private void saved_inf()
        {
            _settingsequalizer.VoiceNameLeft = ValueOfIndexInVoices(SliderLeft.Value);
            _settingsequalizer.VoiceNameMid = ValueOfIndexInVoices(SliderMid.Value);
            _settingsequalizer.VoiceNameRight = ValueOfIndexInVoices(SliderRight.Value);
            _settingsequalizer.Speed = trackBarSpeed.Value;
            _settingsequalizer.Volume = trackBarVolume.Value;
            _settingsequalizer.Save();
        }

        #endregion
    }
}
