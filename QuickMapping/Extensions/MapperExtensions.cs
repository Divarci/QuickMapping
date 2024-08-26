using QuickMapping.Concrete;
using QuickMapping.Concrete.CollectionMappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;

namespace QuickMapping.Extensions;
public static class MapperExtensions
{
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
