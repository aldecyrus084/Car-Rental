using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Interfaces.FileStorage;
using MyApp.Application.Interfaces.Repository;
using MyApp.Infrastructure.Persistence;
using MyApp.Infrastructure.Repository;
using MyApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBranchRepository, BranchesRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<ICustomerDocumentsRepository, CustomerDocumentRepository>();
            services.AddScoped<ICustomerFilesRepository, CustomerFilesRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleImagesRepository, VehicleImagesRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypesRepository>();
            services.AddScoped<IRentalAgreementRepository, RentalAgreementRepository>();
            services.AddScoped<IPricingAreaRepository, PricingAreaRepository>();
            services.AddScoped<IPricingAreaRuleRepository, PricingAreaRuleRepository>();
            services.AddScoped<IVehicleMaintenanceRepository, VehicleMaintenanceRepository>();
            services.AddScoped<IFileStorageServices, FileStorageServices>();
            services.AddScoped<IRentalDestinationRepository, RentalDestinationRepository>();
            services.AddScoped<IRentalVehicleRepository, RentalVehicleRepository>();
            services.AddScoped<IRentalDocumentRepository, RentalDocumentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
