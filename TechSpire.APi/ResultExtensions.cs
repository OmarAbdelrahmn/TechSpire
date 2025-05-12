﻿using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Abstraction;

namespace TechSpire.APi;

public static class ResultExtensions
{
    public static ObjectResult ToProblem(this Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException("Cannot convert a successful result to a problem.");


        var problem = Results.Problem(statusCode: result.Error.StatuesCode);

        var problemDetails = problem.GetType().GetProperty("ProblemDetails")!.GetValue(problem) as ProblemDetails;

        problemDetails!.Extensions = new Dictionary<string, object?>
        {
            { "error", new { result.Error.Code , result.Error.Description } }
        };


        return new ObjectResult(problemDetails);
    }
}
