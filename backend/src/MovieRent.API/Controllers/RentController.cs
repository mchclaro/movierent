using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Rent;
using Domain.Interfaces.Repositories;
using Domain.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace MovieRent.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : Controller
    {
        IRentRepository rentRepository;
        public RentController(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;
        }

        //cria uma nova locação
        [HttpPost("new")]
        public async Task<IActionResult> Create ([FromBody] RentCreateReqDTO dto)
        {
            var res = await rentRepository.Create(dto.FromCreateToEntity());

            return Ok(res);
        }

        //atualiza uma locação
        [HttpPut("update")]
        public async Task<IActionResult> Update ([FromBody] RentUpdateReqDTO dto)
        {
            var exists = await rentRepository.Exists(dto.Id);
            if  (exists == false)
            {
                return Conflict("Locação não encontrada!");
            }

            var update = dto;
            update.RentalDate = dto.RentalDate;
            update.ReturnDate = dto.ReturnDate;
            update.IsReturned = dto.IsReturned;

            await rentRepository.Update(update.FromUpdateToEntity());

            return Ok();
        }

        //obtem todos as locações
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll ()
        {
            var res = await rentRepository.ReadAll();

            return Ok(res.FromReadAllResToDTO());
        }

        //obtem uma locação por id
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var res = await rentRepository.Read(id);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res.FromReadResToDTO());
        }

        //exclui uma locação
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await rentRepository.Exists(id);
            if  (exists == false)
            {
                return Conflict("Locação não encontrada!");
            }

            await rentRepository.Delete(id);

            return Ok();

        }
    }
}