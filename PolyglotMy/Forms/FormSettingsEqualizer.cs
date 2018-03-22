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
                comboVoices.DataSource = Voices;
                comboVoices.ValueMember = "InstalledVoice";
                comboVoices.DisplayMember = "Name";
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
                SliderLeft.Value = _settingsequalizer.SliderLeft;
            }
            catch
            {
                SliderLeft.Value = SliderLeft.Minimum;
            }
            try
            {
                SliderRight.Value = _settingsequalizer.SliderRight;
            }
            catch
            {
                SliderRight.Value = SliderRight.Minimum;
            }
            try
            {
                SliderMid.Value = _settingsequalizer.SliderMid;
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

        private void initionVoice()
        {
            try
            {
                //comboVoices.Text = _settingsequalizer.VoiceName;
                //comboVoices.Text = "Microsoft Server Speech Text to Speech Voice (en-AU, Hayley)";

                comboVoices.SelectedIndex = 2;
            }
            catch
            {
                
            }
            
        }
        
        #endregion

        #region Others

        private void saved_inf()
        {
            _settingsequalizer.SliderLeft = SliderLeft.Value;
            _settingsequalizer.SliderMid = SliderMid.Value;
            _settingsequalizer.SliderRight = SliderRight.Value;
            _settingsequalizer.Save();
        }

        #endregion
    }
}
