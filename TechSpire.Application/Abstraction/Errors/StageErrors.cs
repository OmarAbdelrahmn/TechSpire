using Microsoft.AspNetCore.Http;

namespace TechSpire.Application.Abstraction.Errors;
public static class StageErrors
{
    public static readonly Error NoStageFound = new("Stage.NoStageFound", "We can't find stages", StatusCodes.Status404NotFound);
}
