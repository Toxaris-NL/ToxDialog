using System.Resources;
using System.Windows.Forms;

namespace ToxDialog
{
    internal static class Extensions
    {
        public static string GetButtonName(TDialogResult button)
        {
            ResourceManager loc = new ResourceManager("ToxDialog.Localization", typeof(TDialog).Assembly);
            switch (button)
            {
                case TDialogResult.Abort:
                    return loc.GetString("AbortText");

                case TDialogResult.Cancel:
                    return loc.GetString("CancelText");

                case TDialogResult.Close:
                    return loc.GetString("CloseText");

                case TDialogResult.Continue:
                    return loc.GetString("ContinueText");

                case TDialogResult.Ignore:
                    return loc.GetString("IgnoreText");

                case TDialogResult.No:
                    return loc.GetString("NoText");

                case TDialogResult.NoToAll:
                    return loc.GetString("NoToAllText");

                case TDialogResult.OK:
                    return loc.GetString("OKText");

                case TDialogResult.Retry:
                    return loc.GetString("RetryText");

                case TDialogResult.Yes:
                    return loc.GetString("YesText");

                case TDialogResult.YesToAll:
                    return loc.GetString("YesToAllText");

                default:
                    return loc.GetString("NoneText");
            }
        }

        public static DialogResult MakeDialogResult(TDialogResult result)
        {
            switch (result)
            {
                case TDialogResult.Abort:
                    return DialogResult.Abort;

                case TDialogResult.Cancel:
                case TDialogResult.Close:
                    return DialogResult.Cancel;

                case TDialogResult.Ignore:
                    return DialogResult.Ignore;

                case TDialogResult.No:
                case TDialogResult.NoToAll:
                    return DialogResult.No;

                case TDialogResult.OK:
                case TDialogResult.Continue:
                    return DialogResult.OK;

                case TDialogResult.Retry:
                    return DialogResult.Retry;

                case TDialogResult.Yes:
                case TDialogResult.YesToAll:
                    return DialogResult.Yes;

                default:
                    return DialogResult.None;
            }
        }

        public static TDialogDefaultButton MakeToxDialogDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1:
                    return TDialogDefaultButton.Button1;

                case MessageBoxDefaultButton.Button2:
                    return TDialogDefaultButton.Button2;

                case MessageBoxDefaultButton.Button3:
                    return TDialogDefaultButton.Button3;

                default:
                    return TDialogDefaultButton.None;
            }
        }
    }
}