using AutoMapper;
using OnlineExam.DATA.Entites;
using OnlineExam.SERVICE.DTOs.RoleModels;
using OnlineExam.SERVICE.DTOs.UserModels;

namespace OnlineExam.SERVICE.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserRegisterModel>().ReverseMap();

            CreateMap<User, UpdateUserModel>().ReverseMap();

            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<User, UserRolesModel>()

            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles)); // Ensure this mapping is correct

            CreateMap<Role, RoleModel>(); // Make sure Role -> RoleModel mapping exists
        }
    }
}
