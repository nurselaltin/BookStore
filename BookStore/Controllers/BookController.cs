using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.Model;
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

        public BookController(BookStoreInMemoryContext context)
        {
            _context = context;
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

            try
            {
                BookDetailQuery query = new BookDetailQuery(_context);
                query.BookID = id;
                
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

          
            return Ok(result);

        }


        [HttpPost]
        
        public IActionResult Add([FromBody] CreateBookModel newBook)
        {
            CreateBookCommend commend = new CreateBookCommend(_context);

            try
            {
                commend.Model = newBook;
                commend.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBookModel newBook)
        {

         
            var result = new UpdateBookViewModel();
            

            try
            {
                UpdateBookCommend commend = new UpdateBookCommend(_context);
                commend.BookId = id;
                commend.Model = newBook;
                result = commend.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


          

            try
            {
                DeleteBookCommend commend = new DeleteBookCommend(_context);
                commend.BookId = id;
                commend.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();

        }














    }
}
