using System;

namespace ToxDialog
{
    public class ToxDialogButton
    {
        #region Fields & Properties

        /// <summary>
        /// Determines whether the button should contain a custom text.
        /// </summary>
        public bool UseCustomText { get; set; }

        /// <summary>
        /// The custom text shown on the button.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Determines the value returned to the parent form when the button is clicked.
        /// </summary>
        public ToxDialogResult ToxDialogResult { get; set; }

        /// <summary>
        /// Determines whether to show the elevation icon (shield).
        /// </summary>
        public bool ShowElevationIcon { get; set; }

        #endregion Fields & Properties

        #region Events

        public event EventHandler Click;

        internal void RaiseClickEvent(object sender, EventArgs e)
        {
            Click?.Invoke(sender, e);
        }

        #endregion Events

        #region Constructors

        /// <summary>
        /// Initializes the new instance of ToxDialogButton.
        /// </summary>
        /// <param name="toxDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        public ToxDialogButton(ToxDialogResult toxDialogResult)
        {
            ToxDialogResult = toxDialogResult;
        }

        /// <summary>
        /// Initializes the new instance of ToxDialogButton.
        /// </summary>
        /// <param name="toxDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        /// <param name="showElevationIcon">Determines whether to show the elevation icon (shield).</param>
        public ToxDialogButton(ToxDialogResult toxDialogResult, bool showElevationIcon)
        {
            ToxDialogResult = toxDialogResult;
            ShowElevationIcon = showElevationIcon;
        }

        /// <summary>
        /// Initializes the new instance of ToxDialogButton.
        /// </summary>
        /// <param name="text">The custom text shown on the button.</param>
        /// <param name="click">">Occurs when the button is clicked, but before the form is closed.</param>
        public ToxDialogButton(string text, EventHandler click)
        {
            UseCustomText = true;
            Text = text;
            ToxDialogResult = ToxDialogResult.None;
            Click += click;
        }

        /// <summary>
        /// Initializes the new instance of ToxDialogButton.
        /// </summary>
        /// <param name="text">The custom text shown on the button.</param>
        /// <param name="click">Occurs when the button is clicked, but before the form is closed.</param>
        /// <param name="showElevationIcon">Determines whether to show the elevation icon (shield).</param>
        public ToxDialogButton(string text, EventHandler click, bool showElevationIcon)
        {
            UseCustomText = true;
            Text = text;
            ToxDialogResult = ToxDialogResult.None;
            Click += click;
            ShowElevationIcon = showElevationIcon;
        }

        /// <summary>
        /// Initializes the new instance of ToxDialogButton.
        /// </summary>
        /// <param name="toxDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        /// <param name="text">The custom text shown on the button.</param>
        public ToxDialogButton(ToxDialogResult toxDialogResult, string text)
        {
            UseCustomText = true;
            Text = text;
            ToxDialogResult = toxDialogResult;
        }

        /// <summary>
        /// Initializes the new instance of ToxDialogButton.
        /// </summary>
        /// <param name="toxDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        /// <param name="text">The custom text shown on the button.</param>
        /// <param name="showElevationIcon">Determines whether to show the elevation icon (shield).</param>
        public ToxDialogButton(ToxDialogResult toxDialogResult, string text, bool showElevationIcon)
        {
            UseCustomText = true;
            Text = text;
            ToxDialogResult = toxDialogResult;
            ShowElevationIcon = showElevationIcon;
        }

        #endregion Constructors
    }
}