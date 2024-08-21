using Microsoft.Extensions.DependencyInjection;
using QuickMapping.Abstract;
using QuickMapping.Concrete;

namespace QuickMapping.Extensions;
public static class ServiceExtension
{
    public static IServiceCollection AddQuickMapping(this IServiceCollection service)
    {
        service.AddScoped<IQuickMapper,QuickMapper>();
        return service;
    }
}
