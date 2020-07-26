using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Models;
using Room = WolfPeopleKill.Models.Room;

namespace WolfPeopleKill.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DBModels.Room, Room>();
            CreateMap<Room, DBModels.Room>();
            CreateMap<GameRoom, GamePlay>();
            CreateMap<GamePlay, GameRoom>();
        }

    }
}
