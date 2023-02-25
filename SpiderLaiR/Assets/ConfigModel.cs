namespace SpiderLaiR.Assets
{
    public class ConfigModel
    {
        public RunStyle RunStyle { get; set; }
        public bool IsChecked { get; set; }
    }

    public enum RunStyle
    {
        Normal,
        Tray
    }
}