using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<int> Create(Movie movie);
        Task Update(Movie movie);
        Task<List<Movie>> ReadAll();
        Task<Movie> Read(int id);
        Task Delete(int id);
        Task<bool> Exists(int id);
        // Task<List<Movie>> NeverRented(Movie movie);
        // Task<List<Movie>> MostRented(Movie movie);
        // Task<List<Movie>> LessRented(Movie movie);
    }
}