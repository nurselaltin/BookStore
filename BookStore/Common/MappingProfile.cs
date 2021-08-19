using AutoMapper;
using BookStore.Application.AuthorOperations.Commends.CreateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.GetBookDetail;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.BookOperations.UpdateBook;
using BookStore.Application.GenreOprations.Commends.GetGenreDetails;
using BookStore.Application.GenreOprations.Commends.GetGenres;
using BookStore.Entities;
using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Common
{
    //AutoMapperin config sınıfı olacak burası
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();//Source , Target
            CreateMap<Book, BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=> src.Genre.Name)).ForMember(dest => dest.Author , opt => opt.MapFrom(src => src.Author.FirstName +" "+ src.Author.LastName));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));
            CreateMap<UpdateBookModel, Book>();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
           // CreateMap<GetAuthorDetailQuery, GetAuthorDetailViewModel>().ForMember()
            // CreateMap<Book, UpdateBookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }

    }
}
