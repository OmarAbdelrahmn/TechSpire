using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Abstraction.Errors;
using TechSpire.Application.Contracts.Stage;
using TechSpire.Application.Services;
using TechSpire.infra.Dbcontext;

namespace TechSpire.infra.Services;
public class StageService(AppDbcontext dbcontext) : IStageService
{
    private readonly AppDbcontext dbcontext = dbcontext;

    public async Task<Result<IEnumerable<StageResponse>>> GetAllStagesWithData()
    {
        var stages = await dbcontext.Stages
            .ProjectToType<StageResponse>()
            .AsNoTracking()
            .ToListAsync();

        if (stages == null)
            return Result.Failure<IEnumerable<StageResponse>>(StageErrors.NoStageFound);

        return Result.Success<IEnumerable<StageResponse>>(stages);
    }

    public async Task<Result<StageResponse>> GetStageWithData(int Id)
    {
        var stage = await dbcontext.Stages
            .Where(x => x.Id == Id)
            .ProjectToType<StageResponse>()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (stage == null)
            return Result.Failure<StageResponse>(StageErrors.NoStageFound);

        return Result.Success(stage);
    }
}
