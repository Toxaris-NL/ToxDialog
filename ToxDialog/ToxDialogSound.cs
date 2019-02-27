using Microsoft.Win32;
using System;
using System.IO;
using System.Media;
using System.Security;

namespace ToxDialog
{
    public interface ISound
    {
        /// <summary>
        /// Plays the sound
        /// </summary>
        void Play();
    }

    public sealed class ToxDialogSound : ISound
    {
        private readonly string name;
        private static readonly string mediaPath = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\Media\");

        internal ToxDialogSound(string name)
        {
            this.name = name;
        }

        public void Play()
        {
            try
            {
                string soundPath = Registry.GetValue((@"HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\" + name + @"\.Current"), null, null) as string;
                if (!File.Exists(soundPath) && File.Exists(Path.Combine(mediaPath, soundPath)))
                {
                    soundPath = Path.Combine(mediaPath, soundPath);
                }
                if (File.Exists(soundPath))
                {
                    using (SoundPlayer player = new SoundPlayer(soundPath))
                    {
                        player.Play();
                    }
                }
            }
            catch (IOException e)
            {
            }
            catch (UriFormatException e)
            {
            }
            catch (TimeoutException e)
            {
            }
            catch (ArgumentException e)
            {
            }
            catch (SecurityException e)
            {
            }
            catch (InvalidOperationException e)
            {
            }
        }

        private static ISound _default;
        private static ISound _information;
        private static ISound _question;
        private static ISound _warning;
        private static ISound _error;
        private static ISound _security;

        /// <summary>
        /// Gets the sound associated with the Default program event in the current Windows sound scheme.
        /// </summary>
        public static ISound Default {
            get {
                if (_default == null)
                {
                    _default = new ToxDialogSound(".Default");
                }
                return _default;
            }
        }

        /// <summary>
        /// Gets the sound associated with the Asterisk program event in the current Windows sound scheme.
        /// </summary>
        public static ISound Information {
            get {
                if ((_information == null))
                    _information = new ToxDialogSound("SystemAsterisk");
                return _information;
            }
        }

        /// <summary>
        /// Gets the sound associated with the Question program event in the current Windows sound scheme.
        /// </summary>
        public static ISound Question {
            get {
                if ((_question == null))
                    _question = new ToxDialogSound("SystemQuestion");
                return _question;
            }
        }

        /// <summary>
        /// Gets the sound associated with the Exclamation program event in the current Windows sound scheme.
        /// </summary>
        public static ISound Warning {
            get {
                if ((_warning == null))
                    _warning = new ToxDialogSound("SystemExclamation");
                return _warning;
            }
        }

        /// <summary>
        /// Gets the sound associated with the Hand program event in the current Windows sound scheme.
        /// </summary>
        public static ISound Error {
            get {
                if ((_error == null))
                    _error = new ToxDialogSound("SystemHand");
                return _error;
            }
        }

        /// <summary>
        /// Gets the sound associated with the WindowsUAC program event in the current Windows sound scheme.
        /// </summary>
        /// <remarks>On pre-Vista systems it gets the sound associated with the Hand program event in the current Windows sound scheme.</remarks>
        public static ISound Security {
            get {
                if ((_security == null))
                {
                    if (Environment.OSVersion.Version.Major >= 6)
                        _security = new ToxDialogSound("WindowsUAC");
                    else
                        _security = new ToxDialogSound("SystemHand");
                }
                return _security;
            }
        }
    }
}