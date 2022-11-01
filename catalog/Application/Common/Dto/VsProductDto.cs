//-----------------------------------------------------------------------
// <copyright file="VsProductDto.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Dto
{
    using System.Linq;
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities;

    /// <summary>
    /// The DTO for a product.
    /// </summary>
    public class VsProductDto : IMapFrom<Vsproduct>
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
        /// Gets or sets the Sizes.
        /// </summary>
        public string[] Sizes { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vsproduct, VsProductDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.ProductName, opt => opt.MapFrom(s => s.ProductName))
                .ForMember(p => p.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                .ForMember(p => p.Category, opt => opt.MapFrom(s => s.Category.CategoryName))
                .ForMember(p => p.Sizes, opt => opt.MapFrom(s => s.VsproductSizes.Select(ps => ps.Size.SizeName)));
        }
    }
}