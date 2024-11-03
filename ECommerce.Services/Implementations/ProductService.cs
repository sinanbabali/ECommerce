using ECommerce.Application.Dtos;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Wrappers;
using ECommerce.Domain.Entities;
using ECommerce.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<CreateProductDto> _productValidator;

        public ProductService(IProductRepository productRepository, IValidator<CreateProductDto> productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }
        public ServiceResponse CreateProduct(CreateProductDto productDto)
        {
            var validationResult = _productValidator.Validate(productDto);
            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return ServiceResponse.Fail(errorMessage);
            }

            _productRepository.CreateProduct(productDto);
            return ServiceResponse.Success($"Product '{productDto.Name}' added successfully.", productDto);
        }

        public ServiceResponse GetAllProducts()
        {
            List<ListProductDto> products = _productRepository.GetAll().Select(p => new ListProductDto
            {
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            return ServiceResponse.Success($"{products.Count} records returned.", products);
        }
    }
}
