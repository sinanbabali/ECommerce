using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } 
        public decimal Price { get; set; } 
        public int Stock { get; set; }    
        public int CategoryId { get; set; } 
    }

    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category ID is required.");
        }
    }
}
