using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }


    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Product name is required.");
            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
