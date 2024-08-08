using AutoMapper;
using LibraryApi.Data.DTOs.AuthorDTO;
using LibraryApi.Data.DTOs.BookDTO;
using LibraryApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Data.Mappers
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Author, AuthorGetDTO>().ReverseMap();
            CreateMap<Author,AuthorPostDTO>().ReverseMap();
            CreateMap<Book,BookGetDTO>().ReverseMap();
            CreateMap<Book,BookPostDTO>().ReverseMap();
        }
        
    }
}
