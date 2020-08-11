using AutoMapper;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DBModels.Room, Models.Room>()
                .ForMember(d => d.TotalPlayers, o => o.MapFrom(s => 1));
            CreateMap<Models.Room, DBModels.Room>();
            CreateMap<GamePlay, GameRoom>();
            CreateMap<GameRoom, GamePlay>();
            CreateMap<Role, DBModels.Occupation>();
            CreateMap<DBModels.Occupation, Role>()
                .ForMember(d => d.IsGood, o => o.MapFrom(s => s.OccupationGb))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.About))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.OccupationId))
                .ForMember(d => d.ImgUrl, o => o.MapFrom(s => s.Pic))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.OccupationName));
        }
    }
}
