using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Abstraction.Errors;
using TechSpire.Application.Contracts.Fav;
using TechSpire.Application.Services;
using TechSpire.infra.Dbcontext;

namespace TechSpire.infra.Services;
public class FavService(AppDbcontext dbcontext , UserManager<ApplicataionUser> manager) : IFavService
{
    private readonly AppDbcontext dbcontext = dbcontext;
    private readonly UserManager<ApplicataionUser> manager = manager;

    public async Task<Result> AddItem(string UserId, FavRequest request)
    {
        var ItemIsExicted = await dbcontext.Favs
            .AnyAsync(c=>c.ItemId == request.ItemId && c.UserId == UserId && c.Type == request.Type);

        if (ItemIsExicted)
            return Result.Failure(new Error("Item.repeted", "this item is in your favourite already", StatusCodes.Status400BadRequest));

        if (!Enum.IsDefined(typeof(InSystem), request.Type))
        {
            return Result.Failure(new Error("Invalidrequesttype","this type is in valid try again ",404));
        }

        var fav = request.Adapt<Fav>();

        await dbcontext.AddAsync(fav);
        await dbcontext.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> Clear(string UserId)
    {
        var User = await manager.FindByIdAsync(UserId);

        if (User is null)
            return Result.Failure(UserErrors.UserNotFound);

        var result = await dbcontext.Favs
            .Where(c=>c.UserId == UserId)
            .ExecuteDeleteAsync();

        if (result == 0)
            return Result.Failure(new Error("noDataToDelete", "We didn't find a data to delete", 400));

        return Result.Success();

    }

    public async Task<Result> DeItem(string UserId, FavRequest request)
    {
        var ItemIsExicted = await dbcontext.Favs
            .AnyAsync(c => c.ItemId == request.ItemId && c.UserId == UserId && c.Type == request.Type);

        if (!ItemIsExicted)
            return Result.Failure(new Error("noItem", "no Item found for this user ", StatusCodes.Status400BadRequest));

        var Item = await dbcontext.Favs
            .Where(c => c.ItemId == request.ItemId && c.UserId == UserId && c.Type == request.Type)
            .ExecuteDeleteAsync();

        return Result.Success();
    }

    public async Task<Result<IEnumerable<FavResponse>>> Show(string UserId)
    {
        var User = await manager.FindByIdAsync(UserId);

        if (User is null)
            return Result.Failure <IEnumerable<FavResponse>>(UserErrors.UserNotFound);

        var Items = await dbcontext.Favs
            .Where(c => c.UserId == UserId)
            .ToListAsync();

        if (Items is null)
            return Result.Failure<IEnumerable<FavResponse>>(new Error("NoItemFound", "We didn't find any Items", 400));




        return Result.Success(Items.Adapt<IEnumerable<FavResponse>>());
    }
}
public enum InSystem
{
    Lesson,Article,Post,Book
}