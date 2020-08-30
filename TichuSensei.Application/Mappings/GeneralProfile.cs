using TichuSensei.Application.Features.Products.Commands.CreateProduct;
using TichuSensei.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using TichuSensei.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TichuSensei.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
