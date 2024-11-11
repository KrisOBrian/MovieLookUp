using AutoMapper;
using System.Reflection;
namespace MovieLoopUp.Application.Tests.Mappings;

public class MappingTests
{
    protected static IMapper Setup<T>(params Profile[] childProfiles) where T : Profile, new()
    {
        var assembly = typeof(T).Assembly;
        var types = assembly.GetTypes().Where(t => t.BaseType == typeof(Profile));
        var mapper = new Mapper(new MapperConfiguration(config =>
        {
            foreach (var type in types)
            {
                config.AddProfile(type);
            }
            foreach (var childProfile in childProfiles)
            {
                config.AddProfile(childProfile);
            }
        }));
        return mapper;
    }

    protected static int GetPropertyCount<T>() where T : class
    {
        return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).Length;
    }

    protected class MockChildMapper<TSrc, TDest> : Profile
    {
        public MockChildMapper(TDest destinationObj)
        {
            CreateMap<TSrc, TDest>()
                .ConvertUsing(src => destinationObj);
        }
    }
}