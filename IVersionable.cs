using System;
using System.Collections.Generic;

namespace KyleHughes.AboutDialog.WPF
{
    /// <summary>
    ///     Represents an object which has information pertaining to its version, such as
    ///     product name, version, license information, etc.
    /// </summary>
    public interface IVersionable
    {
        /// <summary>
        ///     Gets or sets the name of this product.
        /// </summary>
        string Product { get; set; }

        /// <summary>
        ///     Gets or sets the title of the product.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     Gets or sets the copyright string for this product.
        /// </summary>
        string Copyright { get; set; }

        /// <summary>
        ///     Gets or sets a user-friendly representation of the version of the product, e.g. 1.0.4.
        /// </summary>
        string Version { get; set; }

        /// <summary>
        ///     Gets or sets a descriptive overview of the product.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets the author or creator of the product.
        /// </summary>
        string Author { get; set; }

        /// <summary>
        ///     Gets or sets the owner or rights holder of the product.
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the license information of the product, ideally would include copyright notice.
        /// </summary>
        string License { get; set; }

        /// <summary>
        ///     Gets or sets the years this license applies to.
        /// </summary>
        int[] Years { get; set; }

        /// <summary>
        ///     Gets or sets whether to show multiple years as a range (i.e. 2013-2015) or as a sequence (i.e. 2013, 2014, 2015).
        /// </summary>
        bool ShowYearsAsRange { get; set; }

        /// <summary>
        ///     Gets or sets a list of pairs of strings and Uris representing clickable links.
        /// </summary>
        IList<Tuple<string, Uri>> Links { get; set; }
    }
}