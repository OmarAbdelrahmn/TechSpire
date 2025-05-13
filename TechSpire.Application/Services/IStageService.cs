using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Stage;

namespace TechSpire.Application.Services;
public interface IStageService
{
    Task<Result<IEnumerable<StageResponse>>> GetAllStagesWithData();
    Task<Result<StageResponse>> GetStageWithData(int Id);
}
