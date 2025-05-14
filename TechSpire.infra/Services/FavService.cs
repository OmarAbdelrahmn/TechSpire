using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Fav;
using TechSpire.Application.Services;

namespace TechSpire.infra.Services;
public class FavService() : IFavService
{
    public Task<Result> AddItem(string UserId, string Type, int ItemId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Clear(string UserId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeItem(string UserId, string Type, int ItemId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IReadOnlyList<FavResponse>>> Show(string UserId)
    {
        throw new NotImplementedException();
    }
}
