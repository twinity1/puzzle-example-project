using FilterExpressionBuilder.Paging;
using Core.Data.Context;
using Core.Data.Seeds;
using Core.Data.Seeds.Entities;
using Modules.Abstraction.Database;
using Modules.Abstraction.DI;
using Modules.Abstraction.DI.Installers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core.Data;

public class DataModuleInstaller(IConfiguration configuration) : IModuleInstaller
{
    public void RegisterModule(IServiceCollection services)
    {
        AddSeeds(services);
    }
    
    private static void AddSeeds(IServiceCollection services)
    {
        services.AddTransient<IEntitySeedService, SeedSeed>();
    }
}
