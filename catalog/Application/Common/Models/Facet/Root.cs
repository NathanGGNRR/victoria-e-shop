//-----------------------------------------------------------------------
// <copyright file="Root.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Facet
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Root of the facet.
    /// </summary>
    public class Root
    {
        /// <summary>
        /// Gets or sets the Aggregations.
        /// </summary>
        [JsonPropertyName("aggregations")]
        public Aggregation Aggregations { get; set; }
    }
}