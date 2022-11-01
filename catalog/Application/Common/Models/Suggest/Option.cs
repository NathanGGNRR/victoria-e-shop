//-----------------------------------------------------------------------
// <copyright file="Option.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Suggest
{
    /// <summary>
    /// Option of ElasticSearch suggest.
    /// </summary>
    public class Option
    {
        /// <summary>
        /// Gets or sets a value indicating whether the collate match.
        /// </summary>
        public bool CollateMatch { get; set; }

        /// <summary>
        /// Gets or sets the Frequency.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Gets or sets the suggest score.
        /// </summary>
        public float SuggestScore { get; set; }

        /// <summary>
        /// Gets or sets the Text.
        /// </summary>
        public string Text { get; set; }
    }
}