using System.Drawing;
using System.Windows.Forms;

namespace ToxDialog
{
    /// <summary>
    /// The actual form
    /// </summary>
    public partial class ToxDialogForm : Form
    {
        public ToxDialogForm()
        {
            InitializeComponent();

            SuspendLayouts();

            Font = SystemFonts.MessageBoxFont;

            LinkLabel1.Font = new Font(Font.FontFamily, Font.Size * 1.5F, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

            ResumeLayouts();
        }

        public void SuspendLayouts()
        {
            TableLayoutPanelContent.SuspendLayout();
            PanelButtons.SuspendLayout();
            TableLayoutPanelButtons.SuspendLayout();
            FlowLayoutPanelButtons.SuspendLayout();
            TableLayoutPanel.SuspendLayout();
            SuspendLayout();
        }

        public void ResumeLayouts()
        {
            TableLayoutPanelContent.ResumeLayout();
            TableLayoutPanelContent.PerformLayout();
            PanelButtons.ResumeLayout();
            PanelButtons.PerformLayout();
            TableLayoutPanelButtons.ResumeLayout();
            TableLayoutPanelButtons.PerformLayout();
            FlowLayoutPanelButtons.ResumeLayout();
            FlowLayoutPanelButtons.PerformLayout();
            TableLayoutPanel.ResumeLayout();
            TableLayoutPanel.PerformLayout();
            ResumeLayout();
            PerformLayout();
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                if (!CanCancel)
                    cp.ClassStyle = cp.ClassStyle | 0x200;// CS_NOCLOSE
                return cp;
            }
        }

        #region Fields & Properties

        private Button _buttons;

        private Button Buttons {
            get {
                if (_buttons == null)
                {
                    _buttons = new Button() { Button1, Button2, Button3 }
                }
                return _buttons;
            }
        }

        private ISound _sound;

        public ISound Sound {
            get {
                if (_sound != null) { return _sound; }
                return ToxDialogSound.Default;
            }
            set {
                _sound = value;
            }
        }

        public string Content {
            get {
                return LabelContent.Text;
            }
            set {
                LabelContent.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    LabelContent.Visible = false;
                    TableLayoutPanelContent.RowStyles[1] = new RowStyle(SizeType.Absolute, 0F);
                }
                else
                {
                    TableLayoutPanelContent.RowStyles[1] = new RowStyle(SizeType.AutoSize);
                    LabelContent.Visible = true;
                }
            }
        }

        public string Title {
            get {
                return LinkLabel1.Text;
            }
            set {
                LinkLabel1.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    LinkLabel1.Visible = false;
                    TableLayoutPanelContent.RowStyles[0] = new RowStyle(SizeType.Absolute, 0F);
                }
                else
                {
                    TableLayoutPanelContent.RowStyles[0] = new RowStyle(SizeType.AutoSize);
                    LinkLabel1.Visible = true;
                }
            }
        }

        public string Caption {
            get {
                return Text;
            }
            set {
                Text = value;
            }
        }

        private bool CanCancel;

        private ToxDialogButton[] toxButtons;

        public ToxDialogButton[] ToxButtons {
            get {
                return toxButtons;
            }
            set {
                if (value == null)
                    value = new ToxDialogButton[] { };
                toxButtons = value;
                if (value.Length == 0)
                {
                    TableLayoutPanelButtons.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0.0F);
                    if (TableLayoutPanelButtons.ColumnStyles[0].SizeType == SizeType.Absolute)
                        TableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.Absolute, 0.0F);
                }
                else
                {
                    TableLayoutPanel.RowStyles[1] = new RowStyle(SizeType.AutoSize);
                    TableLayoutPanelButtons.ColumnStyles[1] = new ColumnStyle(SizeType.AutoSize);
                }

                var loopTo = Buttons.Length - 1;
                for (int i = 0; i <= loopTo; i++)
                {
                    {
                        var withBlock = Buttons[i];
                        withBlock.Visible = i < value.Length;
                        // .Enabled = i < value.Length
                        if (i < value.Length)
                        {
                            if (value[i].TDialogResult == ToxDialogResult.Cancel)
                            {
                                CanCancel = true;
                                CancelButton = Buttons[i];
                            }
                            if (value[i].UseCustomText)
                                withBlock.Text = value[i].Text;
                            else
                                withBlock.Text = GetButtonName(value[i].ToxDialogResult);
                            withBlock.Tag = value[i];
                        }
                    }
                }
                if (value.Length == 1)
                {
                    CanCancel = true;
                    CancelButton = Buttons[0];
                    AcceptButton = Buttons[0];
                }
            }
        }

        public Image Image {
            get {
                return LabelIcon.Image;
            }
            set {
                LabelIcon.Image = value;
                if (value == null)
                    TableLayoutPanelContent.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 0.0F);
                else
                    TableLayoutPanelContent.ColumnStyles[0] = new ColumnStyle(SizeType.AutoSize);
            }
        }

        private bool _drawGradient;
        private Color _gradienBegin;
        private Color _gradientEnd;

        private ToxDialogIcon _mainIcon;

        public ToxDialogIcon MainIcon {
            get { return _mainIcon; }
            set {
                _mainIcon = value;
                TableLayoutPanelContent.SetRowSpan(LabelIcon, 2);
                LinkLabel1.ForeColor = SystemColors.HotTrack;
                _drawGradient = false;
                Sound = ToxDialogSound.Default;

                switch (_mainIcon)
                {
                    case ToxDialogIcon.Information:
                        Image = ToxDialogBigIcon.Information;
                        Sound = ToxDialogSound.Information;
                        break;

                    case ToxDialogIcon.Question:
                        Image = ToxDialogBigIcon.Question;
                        Sound = ToxDialogSound.Question;
                        break;

                    case ToxDialogIcon.Warning:
                        Image = ToxDialogBigIcon.Warning;
                        Sound = ToxDialogSound.Warning;
                        break;

                    case ToxDialogIcon.Error:
                        Image = ToxDialogBigIcon.Error;
                        Sound = ToxDialogSound.Error;
                        break;

                    default:
                        Image = null;
                        break;
                }
            }
        }

        public ToxDialogDefaultButton DefaultButton { get; set; }

        public string ExpandedInformation {
            get {
                return LabelExpandedContent.Text;
            }
            set { LabelExpandedContent.Text = value; }
        }

        private bool _expanded;

        public bool Expanded {
            get { return _expanded; }
            set {
                _expanded = value;
                if (value)
                {
                    LabelExpandedContent.Visible = true;
                    TableLayoutPanelContent.RowStyles[2] = new RowStyle(SizeType.AutoSize);
                }
                else
                {
                    TableLayoutPanelContent.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);
                    LabelExpandedContent.Visible = false;
                }
                UpdateLabelContentMargin();
            }
        }

        public int MaxWidth { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        private Control _control;

        public Control CustomControl {
            get { return _control; }
            set {
                TableLayoutPanelContents.Controls.Clear();
                if (value == null)
                {
                    TableLayoutPanelContents.Visible = false;
                    TableLayoutPanelContent.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
                }
                else
                {
                    TableLayoutPanelContents.Controls.Add(value, 0, 0);
                    value.Dock = DockStyle.Fill;
                    TableLayoutPanelContent.RowStyles[3] = new RowStyle(SizeType.AutoSize);
                    TableLayoutPanelContents.Visible = true;
                }
                _control = value;
                UpdateLabelContentMargin();
            }
        }

        #endregion Fields & Properties

        private void ToxDialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Tag == null)
            {
                if ((CancelButton == null) || (!(CancelButton is Button)) || ((CancelButton as Button).Tag == null))
                { Tag = new ToxDialogButton(ToxDialogResult.Cancel); }
                else
                {
                    Tag = (ToxDialogButton)(CancelButton as Button).Tag;
                }
            }
        }

        private void ToxDialogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_control != null)
            {
                TableLayoutPanelContents.Controls.Remove(_control);
                _control = null;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (LinkLabel1.Visible && LabelContent.Visible)
            {
                LinkLabel1.Margin = new Padding(LinkLabel1.Margin.Left, LinkLabel1.Margin.Top, LinkLabel1.Margin.Right, 0);
                UpdateLabelContentMargin();
            }

            MakeCenter();
        }

        private void UpdateLabelContentMargin()
        {
            LabelContent.Margin = new Padding(LabelContent.Margin.Left, (_drawGradient) ? 16 : 8, LabelContent.Margin.Right, ((!LabelExpandedContent.Visible || string.IsNullOrEmpty(LabelExpandedContent.Text)) && CustomControl == null) ? 16 : 8);
        }

        // TODO OnShow
    }
}