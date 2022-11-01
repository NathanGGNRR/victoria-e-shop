//-----------------------------------------------------------------------
// <copyright file="CreateIndex.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure.Services.ElasticSearch
{
    using Application.Common.Dto;
    using Domain.Entities;
    using Nest;

    /// <summary>
    /// Creates an index for elastic search.
    /// </summary>
    public static class CreateIndex
    {
        /// <summary>
        /// Creates the index descriptor.
        /// </summary>
        /// <param name="indexDescriptor">Index descriptor to setup.</param>
        /// <returns>The index descriptor.</returns>
        public static CreateIndexDescriptor CreateIndexSettingAndMapping(this CreateIndexDescriptor indexDescriptor)
        {
            var analyzerName = "string_product";

            indexDescriptor.Settings(s => s
                .Analysis(a =>
                    a.Analyzers(an => an.Custom(analyzerName, sp => sp.Tokenizer("standard").Filters("lowercase", "stop", "stemmer")))))
                .Map<Vsproduct>(
                    m => m.Properties(props => props.Text(t => t.Name(n => n.ProductName).Analyzer(analyzerName))
                        .Text(t => t.Name(n => n.Description).Analyzer(analyzerName))
                        .Number(nu => nu.Name(n => n.Id).Index(false))
                        .Text(t => t.Name(n => n.ImageUrl).Index(false))
                        .Text(t => t.Name(n => n.ProductUrl).Index(false))
                        .Nested<Vscategory>(o => o
                            .Name(na => na.Category)
                            .Properties(
                                po => po.Keyword(te => te.Name(na => na.CategoryName))))));

            return indexDescriptor;
        }
    }
}