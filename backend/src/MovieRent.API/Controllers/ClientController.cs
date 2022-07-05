using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Client;
using Domain.Interfaces.Repositories;
using Domain.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace MovieRent.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        IClientRepository clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        //cria um novo cliente
        [HttpPost("new")]
        public async Task<IActionResult> Create ([FromBody] ClientCreateReqDTO dto)
        {
            var existsCPF = await clientRepository.ExistsCPF(dto.CPF);
            if (existsCPF == true)
            {
                return Conflict("Esse CPF já está cadastrado!");
            }

            var res = await clientRepository.Create(dto.FromCreateToEntity());

            return Ok(res);
        }

        //atualiza um cliente
        [HttpPut("update")]
        public async Task<IActionResult> Update ([FromBody] ClientUpdateReqDTO dto)
        {
            var exists = await clientRepository.Exists(dto.Id);
            if  (exists == false)
            {
                return Conflict("Cliente não encontrado!");
            }

            var update = dto;
            update.Name = dto.Name;
            update.CPF = dto.CPF;
            update.BirthDate = dto.BirthDate;

            await clientRepository.Update(update.FromUpdateToEntity());

            return Ok();
        }

        //obtem todos os clientes
        [HttpGet("read/all")]
        public async Task<IActionResult> ReadAll ()
        {
            var res = await clientRepository.ReadAll();

            return Ok(res.FromReadAllResToDTO());
        }

        //obtem um cliente por id
        [HttpGet("read/{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var res = await clientRepository.Read(id);

            if (res == null)
            {
                return NotFound();
            }

            return Ok(res.FromReadResToDTO());
        }

        //exclui um cliente
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await clientRepository.Exists(id);
            if  (exists == false)
            {
                return Conflict("Cliente não encontrado!");
            }

            await clientRepository.Delete(id);

            return Ok();
        }
    }
}