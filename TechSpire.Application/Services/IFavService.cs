using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Fav;
using TechSpire.Application.Contracts.Quiz;
using TechSpire.Application.Contracts.Stage;

namespace TechSpire.Application.Services;
public interface IFavService
{
    Task<Result> AddItem(FavRequest request);
    Task<Result> DeItem(FavRequest request);
    Task<Result<IEnumerable<FavResponse>>> Show(string UserId);
    Task<Result> Clear(string UserId);
}
