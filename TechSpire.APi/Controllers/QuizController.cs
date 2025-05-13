using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpire.Application.Services;

namespace TechSpire.APi.Controllers;
[Route("[controller]")]
[ApiController]
public class QuizController(IQuizService service) : ControllerBase
{
    private readonly IQuizService service = service;
}
