//-----------------------------------------------------------------------
// <copyright file="VsColorDto.cs" company="DIIAGE">
//     Victoria e-shop - Groupe 4.
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Dto
{
    using Application.Common.Mappings;
    using AutoMapper;
    using Domain.Entities;

    /// <summary>
    /// DTO for a color.
    /// </summary>
    public class VsColorDto : IMapFrom<Vscolor>
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ColorName.
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the ColorCode.
        /// </summary>
        public string ColorCode { get; set; }

        /// <summary>
        /// Method to map an entity to a DTO.
        /// </summary>
        /// <param name="profile">The profile for the mapping.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vscolor, VsColorDto>()
                .ForMember(p => p.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(p => p.ColorName, opt => opt.MapFrom(s => s.ColorName))
                .ForMember(p => p.ColorCode, opt => opt.MapFrom(s => s.ColorCode));
        }
    }
}
