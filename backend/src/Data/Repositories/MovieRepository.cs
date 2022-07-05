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
    public class MovieRepository : IMovieRepository
    {
        readonly DataContext _context;
        public MovieRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie.Id;
        }

        public async Task Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);

            if (movie == null)
                return;

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var res = await _context.Movies.AnyAsync(c => c.Id == id);
            return res;
        }

        public async Task<Movie> Read(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Movie>> ReadAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task Update(Movie movie)
        {
            var res = await _context.Movies.FirstOrDefaultAsync(c => c.Id == movie.Id);

            if (res == null)
                return;

            res.Title = movie.Title;
            res.Classification = movie.Classification;
            res.MovieType = movie.MovieType;

            await _context.SaveChangesAsync();
        }

        // public async Task<List<Movie>> NeverRented(Movie movie)
        // {
        //     var res = await _context.Movies.Where(c => c.);
        //     return Ok;
        // }

        // public async Task<List<Movie>> MostRented(Movie movie)
        // {
        //     var res = await _context.Movies.Where(c => c.);
        //     return res;
        // }
        // public async Task<List<Movie>> LessRented(Movie movie)
        // {
        //     var res = await _context.Movies.Where(c => c.);
        //     return res;
        // }

    }
}