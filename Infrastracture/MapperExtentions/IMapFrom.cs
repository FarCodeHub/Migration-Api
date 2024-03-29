﻿using AutoMapper;

namespace Infrastracture.MapperExtentions
{
    public interface IMapFrom <T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
