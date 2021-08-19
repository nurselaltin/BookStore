using AutoMapper;
using BookStore.Application.BookOperations.CreateBook;
using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Application.BookOperations.GetBookDetail;
using BookStore.Application.BookOperations.GetBooks;
using BookStore.Application.BookOperations.UpdateBook;
using BookStore.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookStoreInMemoryContext _context; //Sadece burada kullanılsın.readonly : uygulama 
        //içinde değiştirilmesin ve ctor da set edilsin sadece
        private readonly IMapper _mapper;
        public BookController(BookStoreInMemoryContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult Get()
        {

            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = new BookDetailViewModel();

            BookDetailQuery query = new BookDetailQuery(_context, _mapper);
            query.BookID = id;

            result = query.Handle();

            return Ok(result);

        }


        [HttpPost]
        
        public IActionResult Add([FromBody] CreateBookModel newBook)
        {
            CreateBookCommend commend = new CreateBookCommend(_context,_mapper);

            commend.Model = newBook;

            CreateBookCommendValidator val = new CreateBookCommendValidator();

            //Buradan bir hata alırsa MiddlewareException katmanı bu hatayı yakalayacak
            val.ValidateAndThrow(commend);

            //ValidationResult result = val.Validate(commend);

            //if(!result.IsValid)
            //    foreach (var item in result.Errors)
            //    {

            //        Console.WriteLine("Özellik" + item.PropertyName + " - Error Message : " + item.ErrorMessage);
            //    }
            //else
            commend.Handle();

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBookModel newBook)
        {

         
            var result = new UpdateBookViewModel();



            UpdateBookCommend commend = new UpdateBookCommend(_context, _mapper);
            commend.BookId = id;
            commend.Model = newBook;

            UpdateBookCommendValidator val = new UpdateBookCommendValidator();
            val.ValidateAndThrow(commend);



            result = commend.Handle();



            return Ok(result);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {



            DeleteBookCommend commend = new DeleteBookCommend(_context);
            commend.BookId = id;

            DeleteBookCommendValidator val = new DeleteBookCommendValidator();
            val.ValidateAndThrow(commend);

            commend.Handle();

            return Ok();

        }














    }
}
