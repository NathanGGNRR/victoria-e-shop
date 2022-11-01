//-----------------------------------------------------------------------
// <copyright file="CategoryNames.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Facet
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Category names.
    /// </summary>
    public class CategoryNames
    {
        /// <summary>
        /// Gets or sets the document count error.
        /// </summary>
        [JsonPropertyName("doc_count_error_upper_bound")]
        public int DocCountErrorUpperBound { get; set; }

        /// <summary>
        /// Gets or sets the sum of other document count.
        /// </summary>
        [JsonPropertyName("sum_other_doc_count")]
        public int SumOtherDocCount { get; set; }

        /// <summary>
        /// Gets or sets the Bucket.
        /// </summary>
        [JsonPropertyName("buckets")]
        public List<Bucket> Buckets { get; set; }
    }
}