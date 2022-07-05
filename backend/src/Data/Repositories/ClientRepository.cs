using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client.Id;
        }

        public async Task Delete(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
                return;

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Clients.AnyAsync(c => c.Id == id);
            return res;
        }
        public async Task<bool> ExistsCPF(string cpf)
        {
            var res = await _context.Clients.AnyAsync(c => c.CPF == cpf);
            return res;
        }

        public async Task<Client> Read(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Client>> ReadAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task Update(Client client)
        {
            var res = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);

            if (res == null)
                return;

            res.Name = client.Name;
            res.CPF = client.CPF;
            res.BirthDate = client.BirthDate;

            await _context.SaveChangesAsync();
        }
        
    }
}