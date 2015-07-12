using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace KyleHughes.AboutDialog.WPF
{
    internal sealed class ExternalHyperlink : Hyperlink
    {
        public ExternalHyperlink()
        {
            RequestNavigate += ExternalHyperlink_RequestNavigate;
        }

        private void ExternalHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(NavigateUri.AbsoluteUri);
        }
    }
}