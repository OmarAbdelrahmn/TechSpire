using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Abstraction.Errors;
using TechSpire.Application.Contracts.Stage;
using TechSpire.Application.Services;
using TechSpire.infra.Dbcontext;

namespace TechSpire.infra.Services;
public class StageService(AppDbcontext dbcontext , UserManager<ApplicataionUser> manager) : IStageService
{
    private readonly AppDbcontext dbcontext = dbcontext;
    private readonly UserManager<ApplicataionUser> manager = manager;

    public async Task<Result<string>> CompleteLesson(string userId ,int lessonId)
    {
     var user = await manager.FindByIdAsync(userId);

        if (user == null)
            return Result.Failure<string>(UserErrors.UserNotFound);

        if(await dbcontext.Lessons.FindAsync(lessonId) == null)
            return Result.Failure<string>(new Error("NoLessonFound","no lesson found with this id",404));

        user.CompletedLessonIds.Add(lessonId);
        var result = await manager.UpdateAsync(user);


        if (result.Succeeded)
        {
            var stage = await dbcontext.Stages
            .Where(s => s.Lessons.Any(l => l.Id == lessonId))
            .Include(s => s.Lessons)
            .FirstOrDefaultAsync();

            if (stage == null)
                return Result.Failure<string>(StageErrors.NoStageFound);

            var completedLessonIds = user.CompletedLessonIds;


            
                var total = stage!.Lessons.Count;
                var completed = stage.Lessons.Count(l => completedLessonIds.Contains(l.Id));
                double percentage = total == 0 ? 0 : (completed / (double)total) * 100;

            return Result.Success<string>($"{percentage} % is your proccess in this stage");

        }

        var error = result.Errors.FirstOrDefault();

        return Result.Failure<string>(new Error(error!.Code, error.Description, StatusCodes.Status500InternalServerError));

    }

        
    

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
