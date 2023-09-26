using AutoMapper;
using demoWebAPI.Model;

namespace demoWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

        }
    }
}
