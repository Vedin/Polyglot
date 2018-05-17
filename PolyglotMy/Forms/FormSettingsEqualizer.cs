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

        /*
         * Конструктор для случая вызова и передачи формы с которой был вызов (ну или форму которую
         * нужно вызвать после закрытия данной формы)
         */
        public FormSettingsEqualizer(Form formbefore)
        {
            InitializeComponent();
            _initControlls();
            this.formbefore = formbefore;
        }

        /*
         * Открываем форму с которой мы были вызваны
         */
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
            initionPause();
        }

        /*
         * Извлечение масива голосов 
         * От их количества меняеться максимальный размер контролов голосов
         */
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
        /*
         * Инициализация всех контролов для голосов
         */
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

        /*
         * Выгрузка настроек для скрола громкости
         */
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
                trackBarVolume.Value = Globals.EqulizerVolumeDefault;
            }
        }

        /*
         * Выгрузка настроек для скрола скорости
         */
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
        /*
         * Выгрузка настроек пауз между словами и предложениями
         */
        private void initionPause()
        {
            try
            {
                numericUpDSentence.Value = _settingsequalizer.PauseSenteces;
            }
            catch
            {
                numericUpDSentence.Value = numericUpDSentence.Minimum;
            }
            try
            {
                numericUpDWords.Value = _settingsequalizer.PauseWords;
            }
            catch
            {
                numericUpDWords.Value = numericUpDWords.Minimum;
            }
        }

        #endregion

        #region Others
        /*
         * Поиск соответствие сохраненых настроек голоса с теми что установленны на компютере
         * Если соответствие не найдено то выводиться -1 - голос по умолчанию.
         */
        private int IndexOfVoiceInVoices(string VoiceName)
        {
            for(int i = 0; i < Voices.Count;i++)
            {
                if (Voices[i].Name == VoiceName) return i;
            }
            return -1;
        }

        /*
         * Получение название голоса по индексу на скроле
         * Из массва установленных олосов который создаеться при запуске програмы
         * Вывод дефолтного голоса( нулевого по индексу) при выходе за размер массива
         */

        private string ValueOfIndexInVoices(int index)
        {
            if (index < Voices.Count && index >= 0) return Voices[index].Name;
            return Voices[0].Name;
        }

        /*
         * Сохроняет все елементы в клас  settingsequalizer 
         * Запускает метод Save который все сереализирует в Xml файл
         */
        private void saved_inf()
        {
            _settingsequalizer.VoiceNameLeft = ValueOfIndexInVoices(SliderLeft.Value);
            _settingsequalizer.VoiceNameMid = ValueOfIndexInVoices(SliderMid.Value);
            _settingsequalizer.VoiceNameRight = ValueOfIndexInVoices(SliderRight.Value);
            _settingsequalizer.Speed = trackBarSpeed.Value;
            _settingsequalizer.Volume = trackBarVolume.Value;
            _settingsequalizer.PauseSenteces =(int) numericUpDSentence.Value;
            _settingsequalizer.PauseWords = (int)numericUpDWords.Value;

            _settingsequalizer.Save();
        }

        #endregion

        private void SaveSettTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Polyglot (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string defaultFileName = Globals.SettingsFileEqulizer;
                Globals.SettingsFileEqulizer  = saveFileDialog.FileName;
                saved_inf();
                Globals.SettingsFileEqulizer = defaultFileName;
            }
        }

        private void тектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Polyglot (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string defaultFileName = Globals.SettingsFileEqulizer;
                Globals.SettingsFileEqulizer = openFileDialog.FileName;
                _initControlls();
                Globals.SettingsFileEqulizer = defaultFileName;
            }
        }
    }
}
