using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Services.Models.GroupModels;
using ChatApp.Services.Models.MessageModels;
using ChatApp.Services.Models.UserModels;

namespace ChatApp.Services.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        #region User Mappings

        CreateMap<User, UserResponeModel>().ReverseMap();
        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        
        #endregion

        #region Message Mappings

        CreateMap<Message,MessageResponseModel>().ReverseMap();
        CreateMap<Message, MessageCreateModel>().ReverseMap();
        CreateMap<Message,MessageUpdateModel>().ReverseMap();

        #endregion

        #region Group Mappings

        CreateMap<Group,GroupResponseModel>().ReverseMap();
        CreateMap<Group,GroupUpdateModel>().ReverseMap();
        CreateMap<Group, GroupCreateModel>().ReverseMap();

        #endregion

    }
}
