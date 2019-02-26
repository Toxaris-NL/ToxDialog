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

        /// <summary>
        /// Displays a Vista-like message box in front of the specified object and with the specified text and caption.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, MessageBoxButtons.OK);
        }

        /// <summary>
        /// Displays a Vista-like message box with specified text, caption, and buttons.
        /// </summary>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(NullWindow, text, caption, buttons);
        }

        /// <summary>
        /// Displays a Vista-like message box in front of the specified object and with the specified text, caption, and buttons.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return Show(owner, text, caption, buttons);
        }

        /// <summary>
        /// Displays a Vista-like message box with specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(NullWindow, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Displays a Vista-like message box in front of the specified object and with the specified text, caption, buttons, and icon.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Displays a Vista-like message box with specified text, caption, buttons, icon, and default button.
        /// </summary>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
        /// <param name="defaultButton">One of the MessageBoxDefaultButton values that specifies the default button for the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)

        {
            return Show(NullWindow, text, caption, buttons, icon, defaultButton);
        }

        /// <summary>
        /// Displays a Vista-like message box in front of the specified object and with specified text, caption, buttons, icon, and default button.
        /// </summary>
        /// <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
        /// <param name="text">The text to display in the Vista-like message box.</param>
        /// <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
        /// <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
        /// <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
        /// <param name="defaultButton">One of the MessageBoxDefaultButton values that specifies the default button for the Vista-like message box.</param>
        /// <returns>One of the DialogResult values.</returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            ToxDialog newDialog = new ToxDialog
            {
                Content = text,
                WindowTitle = caption
            };
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    newDialog.Buttons = new ToxDialogButton() { new ToxDialogButton(ToxDialogResult.Abort), new ToxDialogButton(ToxDialogResult.Retry), new ToxDialogButton(ToxDialogResult.Ignore) };
                    break;

                case MessageBoxButtons.OKCancel:
                    newDialog.Buttons = new ToxDialogButton() { new ToxDialogButton(ToxDialogResult.OK), new ToxDialogButton(ToxDialogResult.Cancel) };
                    break;

                case MessageBoxButtons.RetryCancel:
                    newDialog.Buttons = new ToxDialogButton() { new ToxDialogButton(ToxDialogResult.Retry), new ToxDialogButton(ToxDialogResult.Cancel) };
                    break;

                case MessageBoxButtons.YesNo:
                    newDialog.Buttons = new ToxDialogButton() { new ToxDialogButton(ToxDialogResult.Yes), new ToxDialogButton(ToxDialogResult.No) };
                    break;

                case MessageBoxButtons.YesNoCancel:
                    newDialog.Buttons = new ToxDialogButton() { new ToxDialogButton(ToxDialogResult.Yes), new ToxDialogButton(ToxDialogResult.No), new ToxDialogButton(ToxDialogResult.Cancel) };
                    break;

                default:
                    newDialog.Buttons = new ToxDialogButton() { new ToxDialogButton(ToxDialogResult.OK) };
                    break;
            }

            switch (icon)
            {
                case MessageBoxIcon.Information:
                    newDialog.MainIcon = ToxDialogIcon.Information;
                    break;

                case MessageBoxIcon.Warning:
                    newDialog.MainIcon = ToxDialogIcon.Warning;
                    break;

                case MessageBoxIcon.Error:
                    newDialog.MainIcon = ToxDialogIcon.Error;
                    break;

                case MessageBoxIcon.Question:
                    newDialog.MainIcon = ToxDialogIcon.Question;
                    break;

                default:
                    newDialog.CustomMainIcon = null;
            }
            newDialog.DefaultButton = MakeToxDialogDefaultButton(defaultButton);
            newDialog.Owner = owner;
            newDialog.Show();
            return MakeDialogResult(newDialog.Result);
        }

        private static void SetStartPosition(Form form, IWin32Window owner)
        {
            if (owner == null)
            {
                form.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                form.StartPosition = FormStartPosition.CenterParent;
            }
        }

        #endregion Messagebox

        #region Methods

        /// <summary>
        /// Shows the TDialog form as a modal dialog box.
        /// </summary>
        /// <returns>One of the TDialogResult values.</returns>
        public ToxDialogResult Show()
        {
            return ShowInternal(owner);
        }

        private ToxDialogResult ShowInternal(IWin32Window owner)
        {
            using (ToxDialogForm form = new ToxDialogForm())
            {
                _form = form;
                form.LinkClicked += LinkClicked;
                form.Load += Load;
                form.RightToLeft = RightToLeft;
                form.RightToLeftLayout = RightToLeftLayout;
                SetStartPosition(_form, owner);
                form.ShowDialog(owner);
                _xPosition = _form.Location.X;
                _yPosition = _form.Location.Y;
                _form = null;
                form.Activate();
                result = (form.Tag as TDialogButton).TDialogResult;
                return result;
            }
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RaiseEvent LinkClicked(sender, e);
        }

        private void Load(object sender, EventArgs e)
        {
            _form.SuspendLayouts();
            _form.Content = Content;
            if (_contentLink != null && _contentLink != _form.LabelContent)
            {
                foreach (LinkLabel.Link link in ContentLinks)
                {
                    _form.LabelContent.Links.Add(link);
                }
                _contentLink.Dispose();
                _contentLink = _form.LabelContent;
            }
            _form.Caption = WindowTitle;
            _form.Title = MainInstruction;
            _form.ToxButtons = Buttons;
            _form.MainIcon = MainIcon;
            if (CustomMainIcon != null)
            {
                _form.Image = CustomMainIcon;
            }
            _form.DefaultButton = DefaultButton;
            if (_expanded != null && _expanded != _form.LabelExpandedContent)
            {
                _expanded.Dispose();
                _expanded = _form.LabelExpandedContent;
            }
            _form.Expanded = ExpandedByDefault;
            _form.CustomControl = CustomControl;
            if (Sound != null)
            {
                _form.Sound = Sound;
            }
            _form.ResumeLayouts();
            _form.xPosition = xPosition;
            _form.yPosition = yPosition;
        }

        private ToxDialogForm _form;

        public void Close(TDialogResult result)
        {
            if (_form != null)
            {
                throw new InvalidOperationException("Cannot invoke this method before the dialog is shown, or after it is closed.");
            }
            ToxDialogButton button = new ToxDialogButton(result);
            _form.Tag = button;
            if (button.ToxDialogResult != ToxDialogResult.None)
            {
                _form.DialogResult = DialogResult.OK;
            }
            int xPosition = _form.Location.X;
            int yPosition = _form.Location.Y;
        }

        #endregion Methods

        #region Fields and Properties

        /// <summary>
        /// Gets or sets a sound played when the Vista-like task dialog is shown.
        /// </summary>
        public isound Sound { get; set; }

        /// <summary>
        /// Gets or sets an implementation of IWin32Window that will own the modal task dialog.
        /// </summary>
        public IWin32Window Owner { get; set; }

        /// <summary>
        /// Gets or sets the text to display in the Vista-like task dialog.
        /// </summary>
        public string Content { get; set; }

        private LinkLabel contentLink;

        /// <summary>
        /// The collection of links contained within the Content LinkLabel.
        /// </summary>
        public readonly LinkLabel.LinkCollection ContentLinks {
            get {
                if (contentLink == null)
                {
                    if (_form != null)
                    {
                        contentLink = form.LabelContent;
                    }
                    else
                    {
                        contentLink = new LinkLabel();
                    }
                }
                return contentLink.Links;
            }
        }

        #endregion Fields and Properties
    }
}