using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Interfaces;

namespace TodoApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        serviceCollection.AddDbContext<TodosDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        serviceCollection.AddScoped<ITodosDbContext>(provider => 
            provider.GetService<TodosDbContext>());
        return serviceCollection;
    }
}