using Consulting.Service.Contract;
using Consulting.Service.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Consulting.Infraestructure.Mapping;
using Microsoft.OpenApi.Models;

namespace Consulting.Infraestructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>();
        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        //public static void AddScopedServices(this IServiceCollection serviceCollection)
        //{
            
        //}

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericService<>));
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("v1", new OpenApiInfo { Title = "Onion Arquitecture API", Version = "v1" });
                //setupAction.SwaggerDoc(
                //    "OpenAPISpecification",
                //    new OpenApiInfo()
                //    {
                //        Title = "Onion Architecture WebAPI",
                //        Version = "1",
                //        Description = "Through this API you can access customer details",
                //        Contact = new OpenApiContact()
                //        {
                //            Email = "e.zaizortega@gmail.com",
                //            Name = "Cristopher Zaiz Ortega",
                //            Url = new Uri("http://czaiz.com/")
                //        },
                //        License = new OpenApiLicense()
                //        {
                //            Name = "MIT License",
                //            Url = new Uri("https://opensource.org/licenses/MIT")
                //        }
                //    });
            });

        }

    }
}
