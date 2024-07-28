using AutoMapper;
using SmartHint.Application.DTOs.ClientDTO;
using SmartHint.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHint.Application.Mappins
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDTO, Client>();
            CreateMap<UpdateClientDTO, Client>();
            CreateMap<ReadClientDTO, Client>();
            CreateMap<Client, ReadClientDTO>();

            CreateMap<PageResult<Client>, PageResult<ReadClientDTO>>()
                    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                    .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(src => src.TotalRecords));
        }
    }
}
