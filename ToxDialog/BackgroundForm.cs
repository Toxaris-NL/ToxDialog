using System.Drawing;
using System.Windows.Forms;

namespace ToxDialog
{
    /// <summary>
    /// Form used in LockSystem mode. Contains an image of grayed desktop.
    /// </summary>
    internal class BackgroundForm : Form
    {
        private Bitmap background;

        public BackgroundForm(Bitmap background)
        {
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Location = Point.Empty;
            Size = Screen.PrimaryScreen.Bounds.Size;
            StartPosition = FormStartPosition.Manual;
            Visible = true;
            this.background = background;
        }

        protected override void OnShown(System.EventArgs e)
        {
            BackgroundImage = background;
            DoubleBuffered = true;
            base.OnShown(e);
        }
    }
}