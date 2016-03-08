namespace ng_table_custom.web.api.App_Start
{
    using AutoMapper;
    using data.Entities;
    using viewmodel;
    public static class AutomapperBootstrap
    {
        public static void Register()
        {
            Mapper.CreateMap<User, UserVM>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<UserVM, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}