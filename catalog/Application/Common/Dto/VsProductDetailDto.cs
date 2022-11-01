//-----------------------------------------------------------------------
// <copyright file="VsProductDetailDto.cs" company="DIIAGE">
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
    /// The DTO for a product's details.
    /// </summary>
    public class VsProductDetailDto : IMapFrom<Vsproduct>
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ImageUrl.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Sizes.
        /// </summary>
        public string[] Sizes { get; set; }

        /// <summary>
        /// Method to map a entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vsproduct, VsProductDetailDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.ProductName, opt => opt.MapFrom(s => s.ProductName))
                .ForMember(p => p.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                .ForMember(p => p.Category, opt => opt.MapFrom(s => s.Category.CategoryName))
                .ForMember(p => p.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(p => p.Brand, opt => opt.MapFrom(s => s.Brand.BrandName))
                .ForMember(p => p.Sizes, opt => opt.MapFrom(s => s.VsproductSizes.Select(ps => ps.Size.SizeName)));
        }
    }
}
