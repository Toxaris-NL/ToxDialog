using System.Resources;
using System.Windows.Forms;

namespace ToxDialog
{
    internal static class Extensions
    {
        public static string GetButtonName(ToxDialogResult button)
        {
            ResourceManager loc = new ResourceManager("ToxDialog.Localization", typeof(ToxDialog).Assembly);
            switch (button)
            {
                case ToxDialogResult.Abort:
                    return loc.GetString("AbortText");

                case ToxDialogResult.Cancel:
                    return loc.GetString("CancelText");

                case ToxDialogResult.Close:
                    return loc.GetString("CloseText");

                case ToxDialogResult.Continue:
                    return loc.GetString("ContinueText");

                case ToxDialogResult.Ignore:
                    return loc.GetString("IgnoreText");

                case ToxDialogResult.No:
                    return loc.GetString("NoText");

                case ToxDialogResult.NoToAll:
                    return loc.GetString("NoToAllText");

                case ToxDialogResult.OK:
                    return loc.GetString("OKText");

                case ToxDialogResult.Retry:
                    return loc.GetString("RetryText");

                case ToxDialogResult.Yes:
                    return loc.GetString("YesText");

                case ToxDialogResult.YesToAll:
                    return loc.GetString("YesToAllText");

                default:
                    return loc.GetString("NoneText");
            }
        }

        public static DialogResult MakeDialogResult(ToxDialogResult result)
        {
            switch (result)
            {
                case ToxDialogResult.Abort:
                    return DialogResult.Abort;

                case ToxDialogResult.Cancel:
                case ToxDialogResult.Close:
                    return DialogResult.Cancel;

                case ToxDialogResult.Ignore:
                    return DialogResult.Ignore;

                case ToxDialogResult.No:
                case ToxDialogResult.NoToAll:
                    return DialogResult.No;

                case ToxDialogResult.OK:
                case ToxDialogResult.Continue:
                    return DialogResult.OK;

                case ToxDialogResult.Retry:
                    return DialogResult.Retry;

                case ToxDialogResult.Yes:
                case ToxDialogResult.YesToAll:
                    return DialogResult.Yes;

                default:
                    return DialogResult.None;
            }
        }

        public static ToxDialogDefaultButton MakeToxDialogDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    return ToxDialogDefaultButton.Button1;

                case MessageBoxDefaultButton.Button2:
                    return ToxDialogDefaultButton.Button2;

                case MessageBoxDefaultButton.Button3:
                    return ToxDialogDefaultButton.Button3;

                default:
                    return ToxDialogDefaultButton.None;
            }
        }
    }
}