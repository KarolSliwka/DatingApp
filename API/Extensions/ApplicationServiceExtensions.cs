using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddCors();

        // services.AddSignleton : only one instance - good for caching date and maitaing state shared for whoel application
        // services.Transient : each time
        // services.AddScope : cerate once per client request, each http request
        services.AddScoped<ITokenServrice, TokenService>();

        return services;
    }
}

// ctrl + shift + l => highlit all that match selection