using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(
            IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MoviesAppDbContext>(x => x.UseSqlServer(connectionString));

            services.AddTransient<IRepository<MovieDto>, MovieRepository>();
            services.AddTransient<IRepository<UserDto>, UserRepository>();

            return services;
        }
    }
}
