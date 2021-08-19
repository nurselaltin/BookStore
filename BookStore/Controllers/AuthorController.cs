using AutoMapper;
using BookStore.Application.AuthorOperations.Commends.CreateAuthor;
using BookStore.Application.AuthorOperations.DeleteAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.BookOperations.DeleteBook;
using BookStore.Model;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly BookStoreInMemoryContext _context; //Sadece burada kullanılsın.readonly : uygulama 
        //içinde değiştirilmesin ve ctor da set edilsin sadece
        private readonly IMapper _mapper;

        private readonly  DeleteBookCommend _deleteBookCommend;
        public AuthorController(BookStoreInMemoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _deleteBookCommend = new DeleteBookCommend(_context);
        }

        [HttpPost]

        public IActionResult Add([FromBody] CreateAuthorModel newAuthor)
        {

            CreateAuthorCommend cmd = new CreateAuthorCommend(_context,_mapper);
            cmd.Model = newAuthor;

            CreateAuthorCommendValidator val = new CreateAuthorCommendValidator();
            val.ValidateAndThrow(cmd);
            cmd.Handle();

            return Ok();


        }


        [HttpGet]
        public IActionResult Get()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context);
            var result = query.Handle();

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            DeleteAuthorCommend cmd = new DeleteAuthorCommend(_context,_deleteBookCommend);
            cmd.AuthorId = id;

            DeleteAuthorCommendValidator val = new DeleteAuthorCommendValidator();
            val.ValidateAndThrow(cmd);
            cmd.Handle();

            return Ok();
            
        }



    }
}
