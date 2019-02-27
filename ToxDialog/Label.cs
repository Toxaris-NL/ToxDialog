using System.Drawing;
using System.Windows.Forms;

namespace ToxDialog
{
    public partial class Label : LinkLabel
    {
        public Label()
        {
            InitializeComponent();

            LinkColor = Color.FromArgb(0, 102, 204);
            ActiveLinkColor = LinkColor;
            DisabledLinkColor = Color.FromArgb(126, 133, 156);
        }

        public override System.Drawing.Size GetPreferredSize(System.Drawing.Size proposedSize)
        {
            proposedSize = base.GetPreferredSize(proposedSize);
            int width = Screen.FromControl(this).WorkingArea.Width / 2;
            proposedSize.Width = (width < proposedSize.Width) ? width : proposedSize.Width;
            return base.GetPreferredSize(proposedSize);
        }
    }
}