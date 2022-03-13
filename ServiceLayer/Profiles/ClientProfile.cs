using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<ClientDetailsDto, Client>();

            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientDetailsDto > ();
        }
    }
}
