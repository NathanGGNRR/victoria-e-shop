namespace Application.Common.Dto
{
    using System.Collections.Generic;

    /// <summary>
    /// Dto of the basket
    /// </summary>
    public class VsBasketDto
    {
        /// <summary>
        /// List of product dto.
        /// </summary>
        public List<VsBasketProductDto> Products { get; set; }
    }
}
