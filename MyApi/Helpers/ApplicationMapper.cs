using AutoMapper;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Helpers;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<Book, BookModel>().ReverseMap();
        // CreateMap<ApplicationUser, SignUpModel>();
    }
}