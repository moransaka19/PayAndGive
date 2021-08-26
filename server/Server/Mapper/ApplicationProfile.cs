using AutoMapper;
using Domain;
using Server.Models;
using Server.Models.Containers;
using Server.Models.Eats;
using Server.Models.Machine;
using Server.Models.Preorders;
using Server.Models.Recalls;
using Server.Models.Restaurants;

namespace Server.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<LoginModel, User>();
            CreateMap<RegisterModel, User>();
            CreateMap<AddRestaurantModel, Restaurant>();
            CreateMap<AddMachineModel, Machine>();
            CreateMap<AddContainerModel, Container>();
            CreateMap<AddEatModel, Eat>();
            CreateMap<AddRecallModel, Recall>();
            CreateMap<Preorder, UserPreorder>()
                .ForMember(dst => dst.CreatedDateTime, src => src.MapFrom(src => src.DateTimePreorder.ToString()));
        }
    }
}
