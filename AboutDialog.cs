using System;
using System.Linq;
using KyleHughes.AboutDialog.WPF.Properties;

namespace KyleHughes.AboutDialog.WPF
{
    /// <summary>
    /// Contains functions for showing an about window and generating a <see cref="IVersionable"/> from an assembly
    /// </summary>
    public static class AboutDialog
    {
        /// <summary>
        /// Creates and shows a new about window in modal mode
        /// </summary>
        /// <param name="versionInfo">A <see cref="IVersionable"/> containing the information to display on the window</param>
        public static void ShowWindow(IVersionable versionInfo)
        {
            (new AboutDialogWindow { DataContext = versionInfo }).ShowDialog();
        }
    }
}
