//-----------------------------------------------------------------------
// <copyright file="VsCategoryDto.cs" company="DIIAGE">
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
    public class VsCategoryDto : IMapFrom<Vscategory>
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Method to map a entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vscategory, VsCategoryDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.CategoryName, opt => opt.MapFrom(s => s.CategoryName));
        }
    }
}