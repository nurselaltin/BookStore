using AutoMapper;
using BookStore.Application.GenreOprations.Commends.CreateGenre;
using BookStore.Application.GenreOprations.Commends.DeleteGenre;
using BookStore.Application.GenreOprations.Commends.GetGenreDetails;
using BookStore.Application.GenreOprations.Commends.GetGenres;
using BookStore.Application.GenreOprations.Commends.UpdateGenre;
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
    public class GenreController : ControllerBase
    {

        private readonly BookStoreInMemoryContext _context; //Sadece burada kullanılsın.readonly : uygulama 
        //içinde değiştirilmesin ve ctor da set edilsin sadece
        private readonly IMapper _mapper;

        public GenreController(BookStoreInMemoryContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj = query.Handle();

            return Ok(obj);
        } 


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            GetGenreDetailQuery query = new GetGenreDetailQuery(_context , _mapper);
            query.GenreId = id;

            GetGenreDetailQueryValidator val = new GetGenreDetailQueryValidator();
            val.ValidateAndThrow(query);
            var result  = query.Handle();

            return Ok(result);


        }



        [HttpPost]

        public IActionResult Add([FromBody] CreateGenreModel newGenre )
        {
            CreateGenreCommend cmd = new CreateGenreCommend(_context );

            cmd.Model = newGenre;

            CreateGenreCommendValidator val = new CreateGenreCommendValidator();
            val.ValidateAndThrow(cmd);

            cmd.Handle();

            return Ok();

        }


        [HttpPut("{id}")]

        public IActionResult Update([FromBody] UpdateGenreModel newGenre,int id)
        {

            UpdateGenreCommend cmd = new UpdateGenreCommend(_context);
            cmd.Model = newGenre;
            cmd.GenreId = id;

            UpdateGenreCommendValidator val = new UpdateGenreCommendValidator();

            val.ValidateAndThrow(cmd);

             cmd.Handle();

            return Ok();


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {



            DeleteGenreCommend commend = new DeleteGenreCommend(_context);
            commend.GenreId = id;

            DeleteGenreCommendValidator val = new DeleteGenreCommendValidator();
            val.ValidateAndThrow(commend);

            commend.Handle();

            return Ok();

        }






    }
}
