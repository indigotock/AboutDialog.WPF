using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using KyleHughes.AboutDialog.WPF.Properties;

namespace KyleHughes.AboutDialog.WPF
{
    /// <summary>
    ///     A class for extracting data from an Assembly.
    /// </summary>
    public sealed class AssemblyVersionInformation : IVersionable
    {
        private static T GetAssemblyAttribute<T>(Assembly a) where T : Attribute
        {
            return a.GetCustomAttribute<T>();
        }

        private readonly string _customLicense;
        private readonly LicenseType _type;

        /// <summary>
        ///     Gets or sets a 64x64 image to display.
        /// </summary>
        public BitmapImage Image { get; set; }

        /// <summary>
        ///     Gets or sets additional text which can be formatted
        /// </summary>
        public string Copy { get; set; }

        /// <summary>
        ///     Gets or sets the product to which this assembly belongs.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        ///     Gets or sets the title of the product.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the copyright string for this product.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        ///     Gets or sets a user-friendly representation of the version of the product, e.g. 1.0.4.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets a descriptive overview of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the author or creator of the product. Defaults to the <see cref="Owner" />
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Gets or sets the owner or rights holder of the product.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the license information of the product, ideally would include copyright notice.
        /// </summary>
        public string License
        {
            get { return GetLicenseText(); }
            set { }
        }

        /// <summary>
        ///     Gets or sets the years this license applies to.
        /// </summary>
        public int[] Years { get; set; }

        /// <summary>
        ///     Gets or sets whether to show multiple years as a range (i.e. 2013-2015) or as a sequence (i.e. 2013, 2014, 2015)
        /// </summary>
        public bool ShowYearsAsRange { get; set; }

        /// <summary>
        ///     Gets or sets a list of pairs of strings and Uris representing clickable links.
        /// </summary>
        public IList<Tuple<string, Uri>> Links { get; set; }

        /// <summary>
        ///     Constructs a new IVersionable with information contained in the given assembly, and the given license type
        /// </summary>
        /// <param name="assembly">The assembly to extract information from</param>
        /// <param name="license">The custom license type</param>
        public AssemblyVersionInformation(Assembly assembly, LicenseType license)
        {
            Title = GetAssemblyAttribute<AssemblyTitleAttribute>(assembly)?.Title;
            Product = GetAssemblyAttribute<AssemblyProductAttribute>(assembly)?.Product;
            Description = GetAssemblyAttribute<AssemblyDescriptionAttribute>(assembly)?.Description;
            Owner = GetAssemblyAttribute<AssemblyCompanyAttribute>(assembly)?.Company;
            Copyright = GetAssemblyAttribute<AssemblyCopyrightAttribute>(assembly)?.Copyright;

            Version = GetAssemblyAttribute<AssemblyInformationalVersionAttribute>(assembly)?.InformationalVersion ??
                      assembly.GetName().Version.ToString();

            _type = license;
        }

        /// <summary>
        ///     Constructs a new IVersionable with information contained in the given assembly, and the given custom license text
        /// </summary>
        /// <param name="assembly">The assembly to extract information from</param>
        /// <param name="license">The custom license type</param>
        public AssemblyVersionInformation(Assembly assembly, string license) : this(assembly, LicenseType.CustomOrNone)
        {
            _customLicense = license;
        }

        /// <summary>
        ///     Constructs a new IVersionable with information contained in the given assembly, and the no license
        /// </summary>
        /// <param name="assembly">The assembly to extract information from</param>
        public AssemblyVersionInformation(Assembly assembly) : this(assembly, LicenseType.CustomOrNone)
        {
            _customLicense = null;
        }

        /// <summary>
        ///     Gets the license text with appropriate substitutions (e.g. year, owner)
        /// </summary>
        /// <returns>The finalised text of the license</returns>
        public string GetLicenseText()
        {
            var yearstring = "";
            if (Years == null || Years.Length == 0)
                yearstring = DateTime.Now.Year.ToString();
            else if (Years.Length == 1)
                yearstring = Years.First().ToString();
            else if (ShowYearsAsRange)
                yearstring = $"{Years.First()}-{Years.Last()}";
            else
                yearstring = string.Join(", ", Years);

            if (_type == LicenseType.Mit)
                return string.Format(Resources.MIT, Environment.NewLine, Copyright);
            if (_type == LicenseType.CustomOrNone)
                return _customLicense;

            return null;
        }
    }
}