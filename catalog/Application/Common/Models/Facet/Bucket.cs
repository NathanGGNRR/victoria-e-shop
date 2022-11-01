//-----------------------------------------------------------------------
// <copyright file="Bucket.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Facet
{
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// A bucket item.
    /// </summary>
    public class Bucket
    {
        /// <summary>
        /// Gets or sets the Key.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the document count.
        /// </summary>
        [JsonProperty("doc_count")]
        [JsonPropertyName("doc_count")]
        public int DocCount { get; set; }
    }
}