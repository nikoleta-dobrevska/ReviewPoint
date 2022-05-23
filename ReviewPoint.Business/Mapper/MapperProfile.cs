using AutoMapper;
using ReviewPoint.Business.ViewModels;
using ReviewPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewPoint.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookViewModel, Book>(); 
            CreateMap<Book, BookViewModel>(); 
            CreateMap<BookDetailsViewModel, Book>();

            CreateMap<GenreViewModel, Genre>();
            CreateMap<Genre, GenreViewModel>();

            CreateMap<AuthorViewModel, Author>();
            CreateMap<Author, AuthorViewModel>();

            CreateMap<ReviewViewModel, Review>();
            CreateMap<Review, ReviewViewModel>();
        }


    }
}
