using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<int> Create(Client client);
        Task Update(Client client);
        Task<List<Client>> ReadAll();
        Task<Client> Read(int id);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<bool> ExistsCPF(string id);
    }
}