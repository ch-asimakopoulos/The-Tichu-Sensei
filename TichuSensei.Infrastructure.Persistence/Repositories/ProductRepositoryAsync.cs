using TichuSensei.Application.Interfaces.Repositories;
using TichuSensei.Domain.Entities;
using TichuSensei.Infrastructure.Persistence.Contexts;
using TichuSensei.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TichuSensei.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _products
                .AllAsync(p => p.Barcode != barcode);
        }
    }
}
