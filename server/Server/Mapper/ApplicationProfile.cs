using AutoMapper;
using Domain;
using Server.Models;
using Server.Models.Containers;
using Server.Models.Eats;
using Server.Models.Machine;
using Server.Models.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<LoginModel, User>()
                .ReverseMap();
            CreateMap<RegisterModel, User>()
                .ReverseMap();
            CreateMap<AddMachineModel, Machine>()
                .ReverseMap();
            CreateMap<CreateMachineContainerModel, MachineContainer>()
                .ReverseMap();
            CreateMap<AddEatModel, Eat>()
                .ReverseMap();
            CreateMap<AddReceiptModel, Receipt>()
                .ReverseMap();

            CreateMap<Machine, MachineModel>()
                .ForMember(x => x.Containers, opt => opt.MapFrom(x => x.MachineContainers));

            CreateMap<MachineContainer, ContainerModel>();

            CreateMap<Eat, EatModel>();
        }
    }
}
