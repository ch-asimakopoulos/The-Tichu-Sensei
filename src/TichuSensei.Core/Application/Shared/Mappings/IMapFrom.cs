using AutoMapper;

namespace TichuSensei.Core.Application.Shared.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

    }
}

