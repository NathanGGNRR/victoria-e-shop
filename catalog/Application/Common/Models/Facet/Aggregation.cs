//-----------------------------------------------------------------------
// <copyright file="Aggregation.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Models.Facet
{
    using Newtonsoft.Json;

    /// <summary>
    /// Aggregation item.
    /// </summary>
    public class Aggregation
    {
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        [JsonProperty("nested#category")]
        public Category Category { get; set; }
    }
}