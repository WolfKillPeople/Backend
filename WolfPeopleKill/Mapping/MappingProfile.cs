using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DBModels.Room, Models.Room>();
            CreateMap<Models.Room, DBModels.Room>();
            CreateMap<GamePlay, DBModels.GameRoom>();
            CreateMap<GameRoom, GamePlay>();
            CreateMap<Role, Occupation>();
            CreateMap<Occupation, Role>()
                .ForMember(d => d.IsGood, o => o.MapFrom(s => s.Occupation_GB))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.About))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.OccupationId))
                .ForMember(d => d.ImgUrl, o => o.MapFrom(s => s.Pic))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Occupation_Name));
        }
    }
}
