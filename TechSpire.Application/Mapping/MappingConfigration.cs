﻿using Mapster;
using TechSpire.Application.Contracts.Auth;
using TechSpire.Application.Contracts.Fav;
using TechSpire.Domain.Entities;


namespace TechSpire.Application.Mapping;

public class MappingConfigration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //config.NewConfig<RegisterRequest, ApplicataionUser>()
        //    .Map(des => des.UserName, src => $"{src.FirstName}{src.LastName}");


        //config.NewConfig<RegisterRequest, ApplicataionUser>()
        //    .Map(des => des.UserName, src => src.Email);
        
        
        //config.NewConfig<FavResponse, Fav>()
        //    .Map(des => des.ItemId, src => src.ItemsId);
       
        
        //config.NewConfig<Fav, FavResponse>()
        //    .Map(des => des.ItemsId, src => src.ItemId);


        //config.NewConfig<(ApplicataionUser user, IList<string> userroles), UserResponse>()
        //    .Map(des => des, src => src.user)
        //    .Map(des => des.Roles, src => src.userroles);
    }
}
