using QuickMapping.Concrete;
using QuickMapping.Concrete.CollectionMappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;

namespace QuickMapping.Extensions;
public static class MapperExtensions
{
    /// <summary>
    /// There are two <strong>params</strong> required. Creates <strong>queryable objects</strong> for LINQ
    /// <list type="number">
    /// <item><param name="source">The <em>source</em> object</param></item>
    /// <item><param name="depth">The count of mapping <em>depth</em></param></item>
    /// </list>
    /// </summary>
    /// <returns>The <strong>queryable object</strong>.</returns>
    public static IQueryable<Destination> MapTo<Source,Destination>(
        this IQueryable<Source> source, 
        int depth, 
        MappingOptions options)
    {
        var mappedObject = IQueryableMapper.Map(
            typeof(IQueryable<Destination>), 
            typeof(Source), 
            typeof(Destination),
            source,
            null,
            depth,
            options, 
            MapperDefaults.COLLECTION) ??
            throw new MapperException("IQueryable Etension Mapper error");

        return (IQueryable<Destination>)mappedObject;
    }
}
