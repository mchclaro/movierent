using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Movie;
using Domain.Entities;

namespace Domain.Mapping
{
    public static class MovieMapper
    {
        public static Movie FromCreateToEntity(this MovieCreateReqDTO movieCreateReqDTO)
        {
            return new Movie
            {
                Title = movieCreateReqDTO.Title,
                Classification = movieCreateReqDTO.Classification,
                MovieType = movieCreateReqDTO.MovieType
            };
        }

        public static Movie FromUpdateToEntity(this MovieUpdateReqDTO movieUpdateReqDTO)
        {
            return new Movie
            {
                Id = movieUpdateReqDTO.Id,
                Title = movieUpdateReqDTO.Title,
                Classification = movieUpdateReqDTO.Classification,
                MovieType = movieUpdateReqDTO.MovieType
            };
        }
        public static List<MovieReadResDTO> FromReadAllResToDTO(this List<Movie> movie)
        {
            return movie.Select(x => new MovieReadResDTO
            {
                Id = x.Id,
                Title = x.Title,
                Classification = x.Classification,
                MovieType = x.MovieType
            }).ToList();
        }
        public static MovieReadResDTO FromReadResToDTO(this Movie movie)
        {
            return new MovieReadResDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Classification = movie.Classification,
                MovieType = movie.MovieType
            };
        }
    }
}