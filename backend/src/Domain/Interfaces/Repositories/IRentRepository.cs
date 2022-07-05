using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRentRepository
    {
        Task<int> Create(Rent rent);
        Task Update(Rent rent);
        Task<List<Rent>> ReadAll();
        Task<Rent> Read(int id);
        Task Delete(int id);
        Task<bool> Exists(int id);
        // Task<List<Client>> DelayReturn(Rent rent);
        // Task<List<Movie>> NeverRented(Rent rent);
        // Task<int> MoreRented(Rent rent);
    }
}