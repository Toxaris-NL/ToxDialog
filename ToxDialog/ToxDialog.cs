using System.Windows.Forms;

namespace ToxDialog
{
    /// <summary>
    /// Displays a Vista-like message box or task dialog that can contain text, buttons, symbols and other elements that inform and instruct the user.
    /// </summary>
    public sealed class ToxDialog
    {
        #region Messagebox

        private static readonly IWin32Window NullWindow = null;

        /// <summary>
        /// Displays a Vista-like message box with specified text.
        /// </summary>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(string text)
        {
            return Show(NullWindow, text);
        }

        /// <summary>
        /// Displays a Vista-like message box in front of the specified object and with the specified text.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text)
        {
            return Show(owner, text, Helper.ApplicationName());
        }

        /// <summary>
        /// Displays a Vista-like message box with specified text and caption.
        /// </summary>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(string text, string caption)
        {
            return Show(NullWindow, text, caption);
        }

        #endregion Messagebox
    }
}