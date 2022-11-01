﻿using Application.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VsBasketProducts.Commands
{
    public class RemoveBasketVsProductsCommand : IRequest<VsBasketDto>
    {
        public int Id { get; set; }
        public string ClientKey { get; set; }
    }
}
