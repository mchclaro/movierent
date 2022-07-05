using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Client;
using Domain.Entities;

namespace Domain.Mapping
{
    public static class ClientMapper
    {
        public static Client FromCreateToEntity(this ClientCreateReqDTO clientCreateReqDTO)
        {
            return new Client
            {
                Name = clientCreateReqDTO.Name,
                CPF = clientCreateReqDTO.CPF,
                BirthDate = clientCreateReqDTO.BirthDate
            };
        }

        public static Client FromUpdateToEntity(this ClientUpdateReqDTO clientUpdateReqDTO)
        {
            return new Client
            {
                Id = clientUpdateReqDTO.Id,
                Name = clientUpdateReqDTO.Name,
                CPF = clientUpdateReqDTO.CPF,
                BirthDate = clientUpdateReqDTO.BirthDate
            };
        }

        public static List<ClientReadResDTO> FromReadAllResToDTO(this List<Client> client)
        {
            return client.Select(x => new ClientReadResDTO
            {
                Id = x.Id,
                Name = x.Name,
                CPF = x.CPF,
                BirthDate = x.BirthDate
            }).ToList();
        }

        public static ClientReadResDTO FromReadResToDTO(this Client client)
        {
            return new ClientReadResDTO
            {
                Id = client.Id,
                Name = client.Name,
                CPF = client.CPF,
                BirthDate = client.BirthDate
            };
        }
    }
}