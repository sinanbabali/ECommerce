using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Persistence.Context;
using ECommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ECommerceDbContext>(opt =>
               opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
