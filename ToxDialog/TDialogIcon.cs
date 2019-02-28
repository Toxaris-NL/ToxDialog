using System.Drawing;

namespace ToxDialog
{
    /// <summary>
    /// Specifies constants defining which icon to display on what background.
    /// </summary>
    public enum TDialogIcon { None, Information, Question, Warning, Error }

    public static class ToxDialogBigIcon
    {
        public readonly static Image Question = Properties.Resources.Question;
        public readonly static Image Information = Properties.Resources.Information;
        public readonly static Image Warning = Properties.Resources.Warning;
        public readonly static Image Error = Properties.Resources.Error;
    }
}