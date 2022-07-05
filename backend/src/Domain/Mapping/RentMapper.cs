using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Rent;
using Domain.Entities;

namespace Domain.Mapping
{
    public static class RentMapper
    {
        public static Rent FromCreateToEntity(this RentCreateReqDTO rentCreateReqDTO)
        {
            return new Rent
            {
                RentalDate = rentCreateReqDTO.RentalDate
            };
        }
        public static Rent FromUpdateToEntity(this RentUpdateReqDTO rentUpdateReqDTO)
        {
            return new Rent
            {
                Id = rentUpdateReqDTO.Id,
                RentalDate = rentUpdateReqDTO.RentalDate,
                ReturnDate = rentUpdateReqDTO.ReturnDate,
                IsReturned = rentUpdateReqDTO.IsReturned,
                MovieId = rentUpdateReqDTO.MovieId,
                ClientId = rentUpdateReqDTO.ClientId,
            };
        }
        public static List<RentReadResDTO> FromReadAllResToDTO(this List<Rent> rent)
        {
            return rent.Select(x => new RentReadResDTO
            {
                Id = x.Id,
                RentalDate = x.RentalDate,
                ReturnDate = x.ReturnDate,
                ClientId = x.ClientId,
                MovieId = x.MovieId,
                IsReturned = x.IsReturned,
            }).ToList();
        }
        public static RentReadResDTO FromReadResToDTO(this Rent rent)
        {
            return new RentReadResDTO
            {
                Id = rent.Id,
                RentalDate = rent.RentalDate,
                ReturnDate = rent.ReturnDate,
                ClientId = rent.ClientId,
                MovieId = rent.MovieId,
            };
        }
    }
}