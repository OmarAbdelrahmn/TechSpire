using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Quiz;
using TechSpire.Application.Contracts.Stage;

namespace TechSpire.Application.Services;
public interface IQuizService
{
    Task<Result<Allinone>> SubmitUserAnswersAsync(string userId, List<UserAnswerRequest> answers);

    Task<Result<List<QuizResponse>>> GetAllQuizsForStage(int stageId);
    Task<Result<QuizResponse>> GetQuizWithId(int Id);
}
