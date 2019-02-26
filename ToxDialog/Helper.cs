using System.Reflection;

namespace ToxDialog
{
    internal static class Helper
    {
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public static string ApplicationName()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            var applicationTitle = ((AssemblyTitleAttribute)entryAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
            if (string.IsNullOrWhiteSpace(applicationTitle))
            {
                applicationTitle = entryAssembly.GetName().Name;
            }
            return applicationTitle;
        }
    }
}