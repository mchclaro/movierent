using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Movie;
using Domain.Interfaces.Repositories;
using Domain.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace MovieRent.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        IMovieRepository movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        //cria um novo filme
        [HttpPost("new")]
        public async Task<IActionResult> Create ([FromBody] MovieCreateReqDTO dto)
        {
            var res = await movieRepository.Create(dto.FromCreateToEntity());

            return Ok(res);
        }

        //atualiza um filme
        [HttpPut("update")]
        public async Task<IActionResult> Update ([FromBody] MovieUpdateReqDTO dto)
        {
            var exists = await movieRepository.Exists(dto.Id);
            if  (exists == false)
            {
                return Conflict("Filme não encontrado!");
            }

            var update = dto;
            update.Title = dto.Title;
            update.Classification = dto.Classification;
            update.MovieType = dto.MovieType;

            await movieRepository.Update(update.FromUpdateToEntity());

            return Ok();
        }

        //obtem todos os filmes
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll ()
        {
            var res = await movieRepository.ReadAll();

            return Ok(res.FromReadAllResToDTO());
        }

        //obtem um filme por id
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var res = await movieRepository.Read(id);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res.FromReadResToDTO());
        }

        //exclui um filme
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await movieRepository.Exists(id);
            if  (exists == false)
            {
                return Conflict("Filme não encontrado!");
            }

            await movieRepository.Delete(id);

            return Ok();
        }
    }
}