using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ToxDialog
{
    [ToolboxBitmap(typeof(Button))]
    [ToolboxItem(true)]
    [ToolboxItemFilter("System.Windows.Forms")]
    [Description("Raises an event when the user clicks it.")]
    public partial class CommandLink : Button
    {
        public CommandLink()
        {
            InitializeComponent();

            base.BackColor = Color.Transparent;
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(21, 28, 85);
            _hotForeColor = Color.FromArgb(7, 74, 229);
            _pressedBorder = Color.FromArgb(153, 118, 118, 118);
            _pressedBackground = Color.FromArgb(102, 222, 225, 225);
            _activeBorderHot1 = Color.FromArgb(163, 0, 201, 253);
            _activeBorderHot2 = Color.FromArgb(128, 0, 201, 253);
            _activeBorderCold = Color.FromArgb(41, 0, 201, 253);
            _hoveredBorder1 = Color.FromArgb(107, 119, 119, 119);
            _hoveredBorder2 = Color.FromArgb(252, 255, 255, 255);
            _hoveredBorder3 = Color.FromArgb(183, 249, 249, 249);
            _hoveredBackground1 = Color.White;
            _hoveredBackground2 = Color.FromArgb(135, 242, 242, 242);
            _hoveredBackground3 = Color.FromArgb(102, 232, 232, 232);
            animatingTo = FrameType.Normal;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);
        }

        public override System.Drawing.Size GetPreferredSize(Size proposedSize)
        {
            proposedSize = base.GetPreferredSize(proposedSize);
            if (proposedSize.Height < 41) { proposedSize.Height = 41; }
            proposedSize.Width = proposedSize.Width * 4 / 3;
            return proposedSize;
        }

        #region Properties & Fields

        private Color _backColor;

        /// <summary>
        /// Gets or sets the background color of the control.
        /// </summary>
        /// <returns>A <see cref="T:System.Drawing.Color" /> value representing the background color.</returns>
        [DefaultValue(typeof(Color), "Transparent")]
        public virtual new Color BackColor {
            get {
                return _backColor;
            }
            set {
                if (!_backColor.Equals(value))
                {
                    _backColor = value;
                    UseVisualStyleBackColor = false;
                    if (IsHandleCreated)
                        CreateFrames();
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <returns>The foreground <see cref="T:System.Drawing.Color" /> of the control.</returns>
        [DefaultValue(typeof(Color), "21, 28, 85")]
        public virtual new Color ForeColor {
            get {
                return base.ForeColor;
            }
            set {
                base.ForeColor = value;
            }
        }

        private Color _hotForeColor;

        /// <summary>
        /// Gets or sets the hot foreground color of the control.
        /// </summary>
        /// <returns>The hot foreground <see cref="T:System.Drawing.Color" /> of the control.</returns>
        [DefaultValue(typeof(Color), "7, 74, 229")]
        [Category("Appearance")]
        public virtual new Color HotForeColor {
            get {
                return _hotForeColor;
            }
            set {
                if (!_hotForeColor.Equals(value))
                {
                    _hotForeColor = value;
                    OnHotForeColorChanged(EventArgs.Empty);
                    if (IsHandleCreated)
                        Invalidate();
                }
            }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            if (IsHandleCreated)
                Invalidate();
        }

        private bool _showElevationIcon;

        /// <summary>
        /// Determines whether to show the elevation icon (shield).
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether the button should be decorated with the security shield icon.")]
        [BrowsableAttribute(true)]
        [DefaultValue(false)]
        public bool ShowElevationIcon {
            get {
                return _showElevationIcon;
            }
            set {
                if (_showElevationIcon != value)
                {
                    _showElevationIcon = value;
                    if (IsHandleCreated)
                    {
                        CreateFrames();
                        Invalidate();
                    }
                }
            }
        }

        private Color _pressedBorder;
        private Color _pressedBackground;
        private Color _activeBorderHot1;
        private Color _activeBorderHot2;
        private Color _activeBorderCold;
        private Color _hoveredBorder1;
        private Color _hoveredBorder2;
        private Color _hoveredBorder3;
        private Color _hoveredBackground1;
        private Color _hoveredBackground2;
        private Color _hoveredBackground3;

        private bool isHovered;
        private bool isFocused;
        private bool isFocusedByKey;
        private bool isKeyDown;
        private bool isMouseDown;

        private bool isPressed {
            get {
                return isKeyDown || (isMouseDown && isHovered);
            }
        }

        [Browsable(false)]
        public PushButtonState State {
            get {
                if (!Enabled) { return PushButtonState.Disabled; }
                if (isPressed) { return PushButtonState.Pressed; }
                if (isHovered) { return PushButtonState.Hot; }
                if (isFocused || IsDefault) { return PushButtonState.Default; }
                return PushButtonState.Normal;
            }
        }

        #endregion Properties & Fields

        #region Events

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.HotForeColor" /> property changes.</summary>
        [Description("Event raised when the value of the HotForeColor property is changed.")]
        [Category("Property Changed")]
        public event EventHandler HotForeColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.HotForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnHotForeColorChanged(EventArgs e)
        {
            HotForeColorChanged?.Invoke(this, e);
        }

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.InnerBorderColor" /> property changes.</summary>
        [Description("Event raised when the value of the InnerBorderColor property is changed.")]
        [Category("Property Changed")]
        public event EventHandler InnerBorderColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.InnerBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnInnerBorderColorChanged(EventArgs e)
        {
            InnerBorderColorChanged?.Invoke(this, e);
        }

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.OuterBorderColor" /> property changes.</summary>
        [Description("Event raised when the value of the OuterBorderColor property is changed.")]
        [Category("Property Changed")]
        public event EventHandler OuterBorderColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.OuterBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnOuterBorderColorChanged(EventArgs e)
        {
            OuterBorderColorChanged?.Invoke(this, e);
        }

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.ShineColor" /> property changes.</summary>
        [Description("Event raised when the value of the ShineColor property is changed.")]
        [Category("Property Changed")]
        public event EventHandler ShineColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.ShineColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnShineColorChanged(EventArgs e)
        {
            ShineColorChanged?.Invoke(this, e);
        }

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.GlowColor" /> property changes.</summary>
        [Description("Event raised when the value of the GlowColor property is changed.")]
        [Category("Property Changed")]
        public event EventHandler GlowColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.GlowColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnGlowColorChanged(EventArgs e)
        {
            GlowColorChanged?.Invoke(this, e);
        }

        #endregion Events

        #region Overrided methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(System.EventArgs e)
        {
            Fade();
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            CreateFrames();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            isKeyDown = false;
            isMouseDown = false;
            Fade();
            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnter(System.EventArgs e)
        {
            isFocused = true;
            isFocusedByKey = true;
            Fade();
            base.OnEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);
            isFocused = false;
            isFocusedByKey = false;
            isKeyDown = false;
            isMouseDown = false;
            Fade();
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnKeyUp(System.Windows.Forms.KeyEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                isKeyDown = true;
                Fade();
                Invalidate();
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnKeyUp(System.Windows.Forms.KeyEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (isKeyDown && e.KeyCode == Keys.Space)
            {
                isKeyDown = false;
                Fade();
                Invalidate();
            }
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!isMouseDown && e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                isFocusedByKey = false;
                Fade();
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isMouseDown)
            {
                isMouseDown = false;
                Fade();
                Invalidate();
            }
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseMove(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.None)
            {
                if (!ClientRectangle.Contains(e.X, e.Y))
                {
                    if (isHovered)
                    {
                        isHovered = false;
                        Fade();
                        Invalidate();
                    }
                }
                else if (!isHovered)
                {
                    isHovered = true;
                    Fade();
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Fade();
            Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            Fade();
            Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion Overrided methods

        #region Painting

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnPaint(System.Windows.Forms.PaintEventArgs)" /> event.
        /// </summary>

        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawButtonBackgroundFromBuffer(e.Graphics);
            DrawButtonForeground(e.Graphics);
            Paint?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when the control is redrawn.
        /// </summary>
        public new event PaintEventHandler Paint;

        private void DrawButtonBackgroundFromBuffer(Graphics graphics)
        {
            if (frames == null || frames.Count.Equals(0))
            {
                CreateFrames();
            }
            if (isAnimating)
            {
                Bitmap alphaImage = new Bitmap(ClientSize.Width, ClientSize.Height);
                DrawAlphaImage(alphaImage, frames[animatingFrom], System.Convert.ToSingle((animationDuration - animationProgress) / animationDuration));
                DrawAlphaImage(alphaImage, frames[animatingTo], System.Convert.ToSingle(animationProgress / animationDuration));
                graphics.DrawImage(alphaImage, Point.Empty);
            }
            else
            {
                graphics.DrawImage(frames[animatingTo], Point.Empty);
            }
        }

        private void DrawAlphaImage(Image alphaImage, Image image, float percent)
        {
            float[][] newColorMatrix = new float[5][];
            newColorMatrix[0] = new float[] { 1, 0, 0, 0, 0 };
            newColorMatrix[1] = new float[] { 0, 1, 0, 0, 0 };
            newColorMatrix[2] = new float[] { 0, 0, 1, 0, 0 };
            newColorMatrix[3] = new float[] { 0, 0, 0, percent, 0 };
            newColorMatrix[4] = new float[] { 0, 0, 0, 0, 1 };
            System.Drawing.Imaging.ColorMatrix matrix = new System.Drawing.Imaging.ColorMatrix(newColorMatrix);
            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
            imageAttributes.ClearColorKey();
            imageAttributes.SetColorMatrix(matrix);
            using (Graphics graphics = Graphics.FromImage(alphaImage))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, Size.Width, Size.Height), 0, 0, Size.Width, Size.Height, GraphicsUnit.Pixel, imageAttributes);
            }
        }

        private Image CreateBackgroundFrame(FrameType frameType)
        {
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;
            Image image = new Bitmap(rect.Width, rect.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.Clear(Color.Transparent);
                DrawButtonBackground(graphics, rect, frameType);
            }
            return image;
        }

        private void DrawButtonBackground(Graphics graphics, Rectangle rectangle, FrameType frameType)
        {
            SmoothingMode sm = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            switch (frameType)
            {
                case FrameType.Pressed:
                    {
                        Rectangle rect = rectangle;
                        rect.Width -= 1;
                        rect.Height -= 1;
                        using (GraphicsPath bw = CreateRoundRectangle(rect, 3))
                        {
                            using (Pen pen = new Pen(_pressedBorder))
                            {
                                graphics.DrawPath(pen, bw);
                            }
                            using (SolidBrush brush = new SolidBrush(_pressedBackground))
                            {
                                graphics.FillPath(brush, bw);
                            }
                        }

                        break;
                    }

                case FrameType.Hovered:
                    {
                        Rectangle rect = rectangle;
                        rect.Width -= 1;
                        rect.Height -= 1;
                        using (GraphicsPath bw = CreateRoundRectangle(rect, 3))
                        {
                            using (Pen pen = new Pen(_hoveredBorder1))
                            {
                                graphics.DrawPath(pen, bw);
                            }
                        }
                        rect.Inflate(-1, -1);
                        using (GraphicsPath bw = CreateRoundRectangle(rect, 2))
                        {
                            using (LinearGradientBrush brush = new LinearGradientBrush(rect, _hoveredBorder2, _hoveredBorder3, LinearGradientMode.Vertical))
                            {
                                using (Pen pen = new Pen(brush))
                                {
                                    graphics.DrawPath(pen, bw);
                                }
                            }
                            if (rect.Height < 40)
                            {
                                using (LinearGradientBrush brush = new LinearGradientBrush(rect, _hoveredBackground1, _hoveredBackground2, LinearGradientMode.Vertical))
                                {
                                    graphics.FillPath(brush, bw);
                                }
                            }
                            else
                            {
                                RectangleF rect1 = rect;
                                rect1.Height *= 0.75F;
                                RectangleF rect2 = rect;
                                rect2.Height -= rect1.Height;
                                rect2.Y += rect1.Height;
                                using (LinearGradientBrush brush = new LinearGradientBrush(rect1, _hoveredBackground1, _hoveredBackground2, LinearGradientMode.Vertical))
                                {
                                    graphics.SetClip(rect1);
                                    graphics.FillPath(brush, bw);
                                    graphics.ResetClip();
                                }
                                using (LinearGradientBrush brush = new LinearGradientBrush(rect2, _hoveredBackground2, _hoveredBackground3, LinearGradientMode.Vertical))
                                {
                                    graphics.SetClip(rect2);
                                    graphics.FillPath(brush, bw);
                                    graphics.ResetClip();
                                }
                            }
                        }

                        break;
                    }

                case FrameType.Active1:
                    {
                        Rectangle rect = rectangle;
                        rect.Width -= 3;
                        rect.X += 1;
                        rect.Height -= 1;
                        using (GraphicsPath bw = CreateRoundRectangle(rect, 3))
                        {
                            using (LinearGradientBrush brush = new LinearGradientBrush(rect, _activeBorderHot1, _activeBorderHot2, LinearGradientMode.Vertical))
                            {
                                using (Pen pen = new Pen(brush))
                                {
                                    graphics.DrawPath(pen, bw);
                                }
                            }
                        }

                        break;
                    }

                case FrameType.Active2:
                    {
                        Rectangle rect = rectangle;
                        rect.Width -= 3;
                        rect.X += 1;
                        rect.Height -= 1;
                        using (GraphicsPath bw = CreateRoundRectangle(rect, 3))
                        {
                            using (Pen pen = new Pen(_activeBorderCold))
                            {
                                graphics.DrawPath(pen, bw);
                            }
                        }

                        break;
                    }
            }

            graphics.SmoothingMode = sm;
        }

        private void DrawButtonForeground(Graphics graphics)
        {
            if (Focused && ShowFocusCues && isFocusedByKey)
            {
                Rectangle rectangle = ClientRectangle;
                rectangle.Inflate(-4, -4);
                ControlPaint.DrawFocusRectangle(graphics, rectangle);
            }

            using (Font font = new Font(Font.FontFamily, Font.SizeInPoints / 0.75F, Font.Style, GraphicsUnit.Point, Font.GdiCharSet, Font.GdiVerticalFont))
            {
                if (!Enabled)
                    TextRenderer.DrawText(graphics, Text, font, new Point(28, 12), Color.Gray, Color.Transparent);
                else if (State == PushButtonState.Hot)
                    TextRenderer.DrawText(graphics, Text, font, new Point(28, 12), HotForeColor, Color.Transparent);
                else
                    TextRenderer.DrawText(graphics, Text, font, new Point(28, 12), ForeColor, Color.Transparent);
            }
        }

        private static GraphicsPath CreateRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int left = rectangle.Left;
            int top = rectangle.Top;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int dia = radius << 1;
            // topleft
            path.AddArc(left, top, dia, dia, 180, 90);
            // top
            path.AddLine(left + radius, top, left + width - radius, top);
            // topright
            path.AddArc(left + width - dia, top, dia, dia, 270, 90);
            // right
            path.AddLine(left + width, top + radius, left + width, top + height - radius);
            // bottomright
            path.AddArc(left + width - dia, top + height - dia, dia, dia, 0, 90);
            // bottom
            path.AddLine(left + width - radius, top + height, left + radius, top + height);
            // bottomleft
            path.AddArc(left, top + height - dia, dia, dia, 90, 90);
            // left
            path.AddLine(left, top + height - radius, left, top + radius);
            path.CloseFigure();
            return path;
        }

        #endregion Painting

        #region Animation

        private Dictionary<FrameType, Image> frames;

        private enum FrameType { Disabled = 0, Pressed = 1, Normal = 2, Hovered = 3, Active1 = 4, Active2 = 5 }

        private void CreateFrames()
        {
            DestroyFrames();
            if (!IsHandleCreated) { return; }
            if (frames == null) { frames = new Dictionary<FrameType, Image>(); }
            frames.Add(FrameType.Disabled, CreateBackgroundFrame(FrameType.Disabled));
            frames.Add(FrameType.Pressed, CreateBackgroundFrame(FrameType.Pressed));
            frames.Add(FrameType.Normal, CreateBackgroundFrame(FrameType.Normal));
            frames.Add(FrameType.Hovered, CreateBackgroundFrame(FrameType.Hovered));
            frames.Add(FrameType.Active1, CreateBackgroundFrame(FrameType.Active1));
            frames.Add(FrameType.Active2, CreateBackgroundFrame(FrameType.Active2));
        }

        private void DestroyFrames()
        {
            if (frames != null)
            {
                frames[FrameType.Disabled].Dispose();
                frames[FrameType.Pressed].Dispose();
                frames[FrameType.Normal].Dispose();
                frames[FrameType.Hovered].Dispose();
                frames[FrameType.Active1].Dispose();
                frames[FrameType.Active2].Dispose();
                frames.Clear();
                frames = null;
            }
        }

        private int animationProgress;
        private FrameType animatingFrom;
        private FrameType animatingTo;
        private int animationDuration;

        private bool isAnimating {
            get {
                return Timer.Enabled;
            }
        }

        private void Fade()
        {
            if (!Enabled)
                FadeTo(FrameType.Disabled, 200);
            else if (isPressed)
                FadeTo(FrameType.Pressed, 200);
            else if (isHovered || isFocusedByKey)
            {
                if (animatingTo == FrameType.Pressed)
                    FadeTo(FrameType.Hovered, 200);
                else
                    FadeTo(FrameType.Hovered, 200);
            }
            else if (isFocused)
            {
                if (animatingTo == FrameType.Hovered)
                    FadeTo(FrameType.Active1, 1000);
                else
                    FadeTo(FrameType.Active1, 200);
            }
            else if (animatingTo == FrameType.Pressed)
                FadeTo(FrameType.Normal, 200);
            else
                FadeTo(FrameType.Normal, 1000);
        }

        private void FadeTo(FrameType frameType, int animationDuration)
        {
            if (animatingTo == frameType)
                return;
            if (animatingFrom == frameType)
            {
                animationProgress = (this.animationDuration - animationProgress) * animationDuration / this.animationDuration;
                this.animationDuration = animationDuration;
                animatingFrom = animatingTo;
                animatingTo = frameType;
            }
            else
            {
                this.animationDuration = animationDuration;
                animationProgress = 0;
                animatingFrom = animatingTo;
                animatingTo = frameType;
            }
            Timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!Timer.Enabled)
                return;
            animationProgress += Timer.Interval;
            if (animationProgress > animationDuration)
            {
                animationProgress = animationDuration;
                if (animatingTo == FrameType.Active1 | animatingTo == FrameType.Active2)
                {
                    if (animatingTo == FrameType.Active1)
                    {
                        animatingFrom = FrameType.Active1;
                        animatingTo = FrameType.Active2;
                    }
                    else
                    {
                        animatingFrom = FrameType.Active2;
                        animatingTo = FrameType.Active1;
                    }
                    animationProgress = 0;
                    animationDuration = 2000;
                }
                else
                    Timer.Enabled = false;
            }
            Refresh();
        }

        #endregion Animation
    }
}