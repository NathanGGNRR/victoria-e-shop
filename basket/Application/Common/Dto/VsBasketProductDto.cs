//-----------------------------------------------------------------------
// <copyright file="VsBasketProductDto.cs" company="Diiage">
//    Diiage
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Dto
{
    /// <summary>
    /// Dto of the basket product
    /// </summary>
    public class VsBasketProductDto
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
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Image link
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the Price of a products
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the number of a products
        /// </summary>
        public int Quantite { get; set; }

        /// <summary>
        /// Gets or sets the size of a products
        /// </summary>
        public string Taille { get; set; }

        /// <summary>
        /// Gets or sets the color of a products
        /// </summary>
        public string Couleur { get; set; }

    }
}
