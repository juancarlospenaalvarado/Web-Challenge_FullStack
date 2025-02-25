using Application.Data;
using Domain.Entities.Permissions;
using Domain.Entities.TypePermissions;
using Domain.Primitives;
using Elasticsearch.Net;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        var credentials = configuration.GetSection("ConnectionStrings");


        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(credentials["SqlServer"]));


        services.AddSingleton<IElasticClient>(sp =>
        {
            var settings = new ConnectionSettings(new Uri(credentials["Uri"]))
                .BasicAuthentication(credentials["user"], credentials["pass"])
                .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
                .DefaultIndex("permission");
            return new ElasticClient(settings);
        });

        
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IPermissionRepository, PermissionsRepository>();
        services.AddScoped<ITypePemissionRepository, TypePemissionRepository>();

        return services;
    }
}