using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RentRepository : IRentRepository
    {
        readonly DataContext _context;
        private readonly ITimeProvider _timeProvider;
        public RentRepository(DataContext context, ITimeProvider timeProvider)
        {
            _context = context;
            _timeProvider = timeProvider;
        }
        public async Task<int> Create(Rent rent)
        {
            await _context.Rents.AddAsync(rent);
            await _context.SaveChangesAsync();

            return rent.Id;
        }

        public async Task Delete(int id)
        {
            var rent = await _context.Rents.FirstOrDefaultAsync(c => c.Id == id);

            if (rent == null)
                return;

            _context.Rents.Remove(rent);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Rents.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<Rent> Read(int id)
        {
            return await _context.Rents
                    .Include(x => x.Client)
                    .Include(x => x.Movie)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Rent>> ReadAll()
        {
            var res = await _context.Rents
                        .Include(a => a.Client)
                        .Include(a => a.Movie)
                        .Select(x => new Rent
                        {
                            Id = x.Id,
                            RentalDate = x.RentalDate,
                            ReturnDate = x.ReturnDate,
                            IsReturned = x.IsReturned,
                            Client = new Client
                            {
                                Id = x.Id,
                                Name = x.Client.Name,
                                CPF = x.Client.CPF,
                                BirthDate = x.Client.BirthDate,
                            },
                            Movie = new Movie
                            {
                                Id = x.Id,
                                Title = x.Movie.Title,
                                Classification = x.Movie.Classification,
                                MovieType = x.Movie.MovieType
                            }
                        })
                        .ToListAsync();
            return res;
        }

        public async Task Update(Rent rent)
        {
            var rents = await _context.Rents.FirstOrDefaultAsync(c => c.Id == rent.Id);
            
            if(rents is null)
                return;

            rents.RentalDate = rent.RentalDate;
            rents.ReturnDate = rent.ReturnDate;
            rents.IsReturned = rent.IsReturned;
        
            await _context.SaveChangesAsync();
        }

        // public async Task<List<Client>> DelayReturn(Rent rent)
        // {
        //     if (rent.ReturnDate > _timeProvider.GetCurrentBrasiliaDate())
        //     {
        //         //lista com os clientes
        //     }
        // }

        // public async Task<int> MoreRented(Rent rent)
        // {
        //     var res =  _context.Rents.Count(x => x.MovieId == rent.MovieId);
        //     return res;
        // }

        // public async Task<List<Movie>> NeverRented(Rent rent)
        // {
        //     var res =  _context.Rents.Where(x => x.IsReturned == false);
        //     return res;
        // }
    }
}