using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Dtos;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Service
{
    class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<Product, ProdcutDto>().ReverseMap();
            CreateMap<UserApp, UserAppDto>().ReverseMap();  
        }
    }
}
