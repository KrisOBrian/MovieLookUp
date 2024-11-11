using AutoMapper;
using MovieLookUp.Application.Models;
using MovieLoopUp.Repository.Models;

namespace MovieLookUp.Application.ApplicationMappings;
public class ApplicationMappings : Profile
{
    public ApplicationMappings()
    {
        CreateMap<MovieDto, Movies>();
    }
}
