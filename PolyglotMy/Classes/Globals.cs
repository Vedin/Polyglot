namespace PolyglotMy
{
    class Globals
    {
        #region File Settings Way
        public static string SettingsFile = "settings.xml";
        public static string SettingsFileEqulizer = "settigsEqulizer.xml";
        public static string SettingsFileText = "settigsText.xml";
        #endregion

        #region Equlizer 
        public static int EqulizerSliderMaxValue = 12;
        public static int EqulizerSliderMinValue = 0;
        public const int EqulizerVolumeMaxValue = 100;
        public const int EqulizerVolumeMinValue = 0;
        public const int EqulizerSpeedMaxValue = 10;
        public const int EqulizerSpeedMinValue = -10;

        //Значения по умолчанию
        public const string SpeechSentizerVoice = "Microsoft Anna";
        #endregion

        #region Const

        public const string ERR = "Error";
        public const string INF = "Information";
        public const string ERRLoadEqulizer = "Not all settings can were load";
        #endregion
    }
}
