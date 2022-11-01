//-----------------------------------------------------------------------
// <copyright file="SuggestRoot.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Suggest
{
    using System.Collections.Generic;

    /// <summary>
    /// ElasticSearch suggest root item.
    /// </summary>
    public class SuggestRoot
    {
        /// <summary>
        /// Gets or sets the Length.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the Offset.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the Options.
        /// </summary>
        public IEnumerable<SuggestRoot> Options { get; set; }

        /// <summary>
        /// Gets or sets the Text.
        /// </summary>
        public string Text { get; set; }
    }
}