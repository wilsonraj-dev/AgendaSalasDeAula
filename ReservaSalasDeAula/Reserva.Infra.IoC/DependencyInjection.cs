﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reserva.Application.Mappings;
using Reserva.Domain.Interfaces;
using Reserva.Infra.Data.Context;
using Reserva.Infra.Data.Repositories;

namespace Reserva.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                                                    x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();

            services.AddAutoMapper(typeof(DomainToDTOProfile));

            return services;
        }
    }
}
