//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Facet
{
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Category item.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the count of documents.
        /// </summary>
        [JsonPropertyName("doc_count")]
        public int DocCount { get; set; }

        /// <summary>
        /// Gets or sets the category names.
        /// </summary>
        [JsonProperty("sterms#categoryNames")]
        [JsonPropertyName("sterms#categoryNames")]
        public CategoryNames CategoryNames { get; set; }
    }
}