using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Wrappers;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext dbContext) : base(dbContext)
        {

        }

        public void CreateProduct(CreateProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}

