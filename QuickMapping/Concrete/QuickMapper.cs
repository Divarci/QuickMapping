using QuickMapping.Abstract;
using QuickMapping.Concrete.Mappers;
using QuickMapping.Exceptions;
using QuickMapping.Options;

namespace QuickMapping.Concrete;
public class QuickMapper : IQuickMapper
{
    public MappingOptions? configurations {  get; }

    public QuickMapper() { }

    public QuickMapper(MappingOptions options) =>
        configurations = options;

    public Destination Map<Source, Destination>(Source source, int depth)
    {
        if (source is null)
            throw new MapperException("Mapper source can not be null");

        if (depth <= 0)
            throw new MapperException("Depth must be greater than 0");

        var mappedObject = ObjectMapper.Map(
            typeof(Source), 
            typeof(Destination), 
            depth, 
            source,
            configurations!);

        return (Destination)mappedObject!;
    }

    public Destination Map<Source, Destination>(Source source, Destination destination, int depth)
    {
        if (source is null)
            throw new MapperException("Mapper source can not be null");

        if (destination is null)
            throw new MapperException("Mapper destination can not be null");

        if (depth <= 0)
            throw new MapperException("Depth must be greater than 0");

        var mappedObject = ObjectMapper.Map(
            typeof(Source), 
            typeof(Destination), 
            depth, 
            source,
            configurations!,
            destination);

        return (Destination)mappedObject!;
    }
}
