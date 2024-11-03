using ECommerce.Application.Dtos;
using ECommerce.Application.Wrappers;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Interfaces
{
    public interface IProductService
    {
        ServiceResponse CreateProduct(CreateProductDto product);
        ServiceResponse GetAllProducts();
    }
}
