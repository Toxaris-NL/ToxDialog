using System;
using System.Windows.Forms;

namespace ToxDialog
{
    /// <summary>
    /// Displays a Vista-like message box or task dialog that can contain text, buttons, symbols and other elements that inform and instruct the user.
    /// </summary>
    public sealed class TDialog
    {
        #region Messagebox

        private static readonly IWin32Window NullWindow;

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
            TDialog newDialog = new TDialog
            {
                Content = text,
                WindowTitle = caption
            };
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    newDialog.Buttons = new TDialogButton[] { new TDialogButton(TDialogResult.Abort), new TDialogButton(TDialogResult.Retry), new TDialogButton(TDialogResult.Ignore) };
                    break;

                case MessageBoxButtons.OKCancel:
                    newDialog.Buttons = new TDialogButton[] { new TDialogButton(TDialogResult.OK), new TDialogButton(TDialogResult.Cancel) };
                    break;

                case MessageBoxButtons.RetryCancel:
                    newDialog.Buttons = new TDialogButton[] { new TDialogButton(TDialogResult.Retry), new TDialogButton(TDialogResult.Cancel) };
                    break;

                case MessageBoxButtons.YesNo:
                    newDialog.Buttons = new TDialogButton[] { new TDialogButton(TDialogResult.Yes), new TDialogButton(TDialogResult.No) };
                    break;

                case MessageBoxButtons.YesNoCancel:
                    newDialog.Buttons = new TDialogButton[] { new TDialogButton(TDialogResult.Yes), new TDialogButton(TDialogResult.No), new TDialogButton(TDialogResult.Cancel) };
                    break;

                default:
                    newDialog.Buttons = new TDialogButton[] { new TDialogButton(TDialogResult.OK) };
                    break;
            }

            switch (icon)
            {
                case MessageBoxIcon.Information:
                    newDialog.MainIcon = TDialogIcon.Information;
                    break;

                case MessageBoxIcon.Warning:
                    newDialog.MainIcon = TDialogIcon.Warning;
                    break;

                case MessageBoxIcon.Error:
                    newDialog.MainIcon = TDialogIcon.Error;
                    break;

                case MessageBoxIcon.Question:
                    newDialog.MainIcon = TDialogIcon.Question;
                    break;

                default:
                    newDialog.CustomMainIcon = null;
                    break;
            }
            newDialog.DefaultButton = Extensions.MakeToxDialogDefaultButton(defaultButton);
            newDialog.Owner = owner;
            newDialog.Show();
            return Extensions.MakeDialogResult(newDialog.Result);
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
        public TDialogResult Show()
        {
            return ShowInternal(Owner);
        }

        private TDialogResult ShowInternal(IWin32Window owner)
        {
            using (TDialogForm form = new TDialogForm())
            {
                this.form = form;
                form.LinkClicked += RaiseLinkClicked;
                form.Load += Load;
                form.RightToLeft = RightToLeft;
                form.RightToLeftLayout = RightToLeftLayout;
                SetStartPosition(this.form, owner);
                form.ShowDialog(owner);
                XPosition = this.form.Location.X;
                YPosition = this.form.Location.Y;
                this.form = null;
                form.Activate();
                Result = (form.Tag as TDialogButton).TDialogResult;
                return Result;
            }
        }

        private void RaiseLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkClicked?.Invoke(sender, e);
        }

        private void Load(object sender, EventArgs e)
        {
            form.SuspendLayouts();
            form.Content = Content;
            if (contentLink != null && contentLink != form.LabelContent)
            {
                foreach (LinkLabel.Link link in ContentLinks)
                {
                    form.LabelContent.Links.Add(link);
                }
                contentLink.Dispose();
                contentLink = form.LabelContent;
            }
            form.Caption = WindowTitle;
            form.Title = MainInstruction;
            form.ToxButtons = Buttons;
            form.MainIcon = MainIcon;
            if (CustomMainIcon != null)
            {
                form.Image = CustomMainIcon;
            }
            form.DefaultButton = DefaultButton;
            if (expanded != null && expanded != form.LabelExpandedContent)
            {
                expanded.Dispose();
                expanded = form.LabelExpandedContent;
            }
            form.Expanded = ExpandedByDefault;
            form.CustomControl = Control;
            if (Sound != null)
            {
                form.Sound = Sound;
            }
            form.ResumeLayouts();
            form.XPosition = XPosition;
            form.YPosition = YPosition;
        }

        private TDialogForm form;

        public void Close(TDialogResult result)
        {
            if (form != null)
            {
                throw new InvalidOperationException("Cannot invoke this method before the dialog is shown, or after it is closed.");
            }
            TDialogButton button = new TDialogButton(result);
            form.Tag = button;
            if (button.TDialogResult != TDialogResult.None)
            {
                form.DialogResult = DialogResult.OK;
            }
            int xPosition = form.Location.X;
            int yPosition = form.Location.Y;
        }

        #endregion Methods

        #region Fields and Properties

        /// <summary>
        /// Gets or sets a sound played when the Vista-like task dialog is shown.
        /// </summary>
        public ISound Sound { get; set; }

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
        public LinkLabel.LinkCollection ContentLinks {
            get {
                if (contentLink == null)
                {
                    if (form != null)
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

        /// <summary>
        /// Gets or sets the text to display in the title bar of the Vista-like task dialog.
        /// </summary>
        public string WindowTitle { get; set; }

        /// <summary>
        /// Gets or sets the text to be used for the main instruction of the Vista-like task dialog.
        /// </summary>
        public string MainInstruction { get; set; }

        /// <summary>
        /// Gets or sets the array of the TDialogButtons that specifies which buttons to display in the Vista-like task dialog.
        /// </summary>
        public TDialogButton[] Buttons { get; set; }

        /// <summary>
        /// Gets or sets the one of the TDialogIcon values that specifies which icon on what background to display in the Vista-like task dialog.
        /// </summary>
        public TDialogIcon MainIcon { get; set; }

        /// <summary>
        /// Gets or sets the custom image to display in the Vista-like task dialog.
        /// </summary>
        public System.Drawing.Image CustomMainIcon { get; set; }

        /// <summary>
        /// Gets or sets one of the TDialogDefaultButton values that specifies the default button for the Vista-like task dialog.
        /// </summary>
        public TDialogDefaultButton DefaultButton { get; set; } = TDialogDefaultButton.Button1;

        /// <summary>
        /// Gets or sets a value indicating whether the text appears from right to left, such as when using Hebrew or Arabic fonts.
        /// </summary>
        public RightToLeft RightToLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether right-to-left mirror placement is turned on.
        /// </summary>
        public bool RightToLeftLayout { get; set; }

        /// <summary>
        /// Gets or sets the dialog result for the TDialog form.
        /// </summary>
        public TDialogResult Result { get; set; }

        /// <summary>
        /// Gets or sets the custom control to display in the Vista-like task dialog.
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the verification checkbox in the dialog should be checked when the dialog is initially displayed.
        /// </summary>
        public CheckState VerificationFlagChecked { get; set; }

        /// <summary>
        /// Gets or sets the string to be used to label the verification checkbox. If this parameter is Nothing (null), the verification checkbox is not displayed in the Vista-like task dialog.
        /// </summary>
        public string VerificationText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the string specified by the ExpandedInformation property should be displayed when the Vista-like task dialog is initially displayed.
        /// </summary>
        public bool ExpandedByDefault { get; set; }

        /// <summary>
        /// Gets or sets the string to be used for displaying additional information. The additional information is displayed either immediately below the content or below the footer text depending on whether the ExpandFooterArea property is set.
        /// </summary>
        public string ExpandedInformation { get; set; }

        private LinkLabel expanded;

        /// <summary>
        /// The collection of links contained within the Footer LinkLabel.
        /// </summary>
        public LinkLabel.LinkCollection ExpandedInformationLinks {
            get {
                if (expanded == null)
                {
                    if (form != null)
                    {
                        expanded = form.LabelExpandedContent;
                    }
                    else
                    {
                        expanded = new LinkLabel();
                    }
                }
                return expanded.Links;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the x position of the form
        /// </summary>
        public int XPosition { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the y position of the form
        /// </summary>
        public int YPosition { get; set; }

        #endregion Fields and Properties

        #region Events

        public event LinkLabelLinkClickedEventHandler LinkClicked;

        #endregion Events
    }
}