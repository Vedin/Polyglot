using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace PolyglotMy
{
    
    public partial class FormSettingsEqualizer : Form
    {
        Form formbefore;
        SettingsEqualizer _settingsequalizer =  null;
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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            saved_inf();
            this.Close();
        }
        private void saved_inf()
        {     
            _settingsequalizer.SliderLeft = SliderLeft.Value;
            _settingsequalizer.SliderMid = SliderMid.Value;
            _settingsequalizer.SliderRight = SliderRight.Value;
            _settingsequalizer.Save();
        }

        private void buttonAplly_Click(object sender, EventArgs e)
        {
            saved_inf();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _initControlls();
        }

        private void _initControlls()
        {
            _settingsequalizer = SettingsEqualizer.GetSettings();
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

        private void FormSettingsEqualizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            formbefore.Show();
        }
    }
}
