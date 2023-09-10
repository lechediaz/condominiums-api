using System.Reflection;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using NamiSic.Application.Common.Interfaces;
using NamiSic.Infrastructure.Mappings;
using NamiSic.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBsonClassMaps();

        string? connectionString = configuration.GetConnectionString("MongoDbUri");
        string? mongoDbname = configuration.GetValue<string>("MongoDbName");

        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Please configure the MongoDbUri section");
            Environment.Exit(1);
        }

        if (string.IsNullOrEmpty(mongoDbname))
        {
            Console.WriteLine("Please configure the MongoDbName section");
            Environment.Exit(1);
        }

        services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));
        services.AddScoped<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbname));

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }

    private static IServiceCollection AddBsonClassMaps(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(BsonClassMap))).ToArray();

        foreach (Type type in types)
        {
            var instance = (BsonClassMap)Activator.CreateInstance(type);
            BsonClassMap.RegisterClassMap(instance);
        }

        return services;
    }
}
