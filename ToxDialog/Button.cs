using System.Drawing;

namespace ToxDialog
{
    public partial class Button : System.Windows.Forms.Button
    {
        public override System.Drawing.Size GetPreferredSize(System.Drawing.Size proposedSize)
        {
            proposedSize = base.GetPreferredSize(proposedSize);
            proposedSize.Width += 24;
            if (Image != null) { proposedSize.Width += Image.Width; }
            proposedSize.Width -= proposedSize.Width % 25;
            proposedSize.Width = (proposedSize.Width < 75) ? 75 : proposedSize.Width;
            proposedSize.Height = (proposedSize.Height < 25) ? 25 : proposedSize.Height;

            return proposedSize;
        }
    }
}