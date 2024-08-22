using Microsoft.Extensions.DependencyInjection;
using QuickMapping.Abstract;
using QuickMapping.Concrete;
using QuickMapping.Options;

namespace QuickMapping.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddQuickMapping(this IServiceCollection service)
    {
        service.AddScoped<IQuickMapper,QuickMapper>();
        return service;
    }

    public static IServiceCollection AddQuickMapping(this IServiceCollection service, Action<MappingOptions> configureOptions)
    {
        var options = new MappingOptions();
        configureOptions(options);

        service.AddScoped<IQuickMapper>(sp => new QuickMapper(options));
        return service;
    }
}
