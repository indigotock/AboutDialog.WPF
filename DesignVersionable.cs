using System;
using System.Collections.Generic;
using KyleHughes.AboutDialog.WPF.Properties;

namespace KyleHughes.AboutDialog.WPF
{
    /// <summary>
    ///     A class for extracting data from an Assembly.
    /// </summary>
    internal sealed class DesignVersionable : IVersionable
    {
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

        public int[] Years { get; set; } = {2013, 2014, 2015};
        public bool ShowYearsAsRange { get; set; } = true;
        public IList<Tuple<string, Uri>> Links { get; set; }
    }
}