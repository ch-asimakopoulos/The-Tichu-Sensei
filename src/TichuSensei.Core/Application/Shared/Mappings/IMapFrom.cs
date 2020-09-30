﻿using AutoMapper;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Shared.Mappings
{
    public interface IMapFrom<T>
    {

        void Mapping(Profile profile)
        {
            if (GetType().Equals(o: new PlayerEloRankingsDTO()))
            {
                profile.CreateMap<Player, PlayerEloRankingsDTO>()
                .ForMember(dto => dto.PlayerEloRankings, o => o.MapFrom(pl => pl.Stats));
                return;
            }

            profile.CreateMap(typeof(T), GetType());
        }

    }

}

