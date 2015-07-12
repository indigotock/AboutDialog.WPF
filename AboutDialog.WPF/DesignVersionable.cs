using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using KyleHughes.AboutDialog.WPF.Properties;

namespace KyleHughes.AboutDialog.WPF
{
    /// <summary>
    ///     A class for extracting data from an Assembly.
    /// </summary>
    internal sealed class DesignVersionable : IVersionable
    {
        public BitmapImage Image { get; set; } = null;
        public string Copy { get; set; } = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In egestas, turpis at tempor tempor, neque metus pretium felis, sed semper risus ligula pulvinar tellus. Maecenas consectetur rutrum dictum. Ut id dolor enim. Nullam nec justo enim. Vivamus a leo sollicitudin, mattis dolor in, maximus dui.";
        public string Product { get; set; } = "A product";
        public string Title { get; set; } = "An Assembly";
        public string Version { get; set; } = "1.0.3";
        public string Description { get; set; } = "A product to do that thing which this product doees";
        public string Author { get; set; } = "John Doe";
        public string Owner { get; set; } = "A Company, Inc.";

        public string License
        {
            get { return string.Format(Resources.MIT, Environment.NewLine, Copyright); }
            set { }
        }

        public string Copyright
        {
            get { return $"Copyright \u00a9 {Author} {string.Join(", ", Years)}"; }
            set { }
        }

        public int[] Years { get; set; } = { 2013, 2014, 2015 };
        public bool ShowYearsAsRange { get; set; } = true;

        public IList<Tuple<string, Uri>> Links
        {
            get { return new List<Tuple<string, Uri>>
            {
                new Tuple<string, Uri>("Link 1", new Uri("http://example.com/")),
                new Tuple<string, Uri>("Link 2", new Uri("http://example.com/"))
            }; }
            set { }
        }
    }
}