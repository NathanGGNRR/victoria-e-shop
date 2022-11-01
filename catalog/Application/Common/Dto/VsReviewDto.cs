//-----------------------------------------------------------------------
// <copyright file="VsReviewDto.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities;

    /// <summary>
    /// The DTO for a review.
    /// </summary>
    public class VsReviewDto : IMapFrom<VsproductReview>
    {
        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Rating.
        /// </summary>
        public decimal? Rating { get; set; }

        /// <summary>
        /// Gets or sets the reviewCount.
        /// </summary>
        public int? ReviewCount { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<VsproductReview, VsReviewDto>()
                .ForMember(p => p.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(p => p.Rating, opt => opt.MapFrom(s => s.Rating))
                .ForMember(p => p.ReviewCount, opt => opt.MapFrom(s => s.ReviewCount));
        }
    }
}
