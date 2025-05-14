using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Application.Abstraction;
using TechSpire.Application.Contracts.Quiz;
using TechSpire.Application.Contracts.Stage;
using TechSpire.Application.Services;
using TechSpire.Domain.Entities;
using TechSpire.infra.Dbcontext;

namespace TechSpire.infra.Services;
public class QuizService(AppDbcontext dbcontext) : IQuizService
{
    private readonly AppDbcontext dbcontext = dbcontext;

    public async Task<Result<List<QuizResponse>>> GetAllQuizsForStage(int stageId)
    {
        var Quizzes = await dbcontext.Quizzes
            .Where(c=>c.StangeId == stageId)
            .ProjectToType<QuizResponse>()
            .AsNoTracking()
            .ToListAsync();

        if (Quizzes == null)
            return Result.Failure<List<QuizResponse>>(new Error("Quiz.Notfound", "No quiz found for the given stage.",StatusCodes.Status404NotFound));

        return Result.Success(Quizzes);
    }

    public async Task<Result<QuizResponse>> GetQuizWithId(int Id)
    {
        var Quizzes = await dbcontext.Quizzes
            .Where(c => c.Id == Id)
            .ProjectToType<QuizResponse>()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (Quizzes == null)
            return Result.Failure<QuizResponse>(new Error("Quiz.Notfound", "No quiz found for the given Quiz ID.", StatusCodes.Status404NotFound));

        return Result.Success(Quizzes);
    }

    public async Task<Result<allinone>> SubmitUserAnswersAsync(string userId, List<UserAnswerRequest> answers)
    {
        #region HelloWorld
        //var userAnswerss = await dbcontext.UserAnswers
        //        .Where(e => e.UserId == userId)
        //        .ToListAsync();

        //var exists = userAnswerss
        //    .Any(e => answers.Any(a => a.QuestionId == e.QuestionId && a.AnswerId == e.AnswerId));

        //var repeted = await dbcontext.UserAnswers
        //    .AnyAsync(ua => ua.UserId == userId && answers.Any(a => a.QuestionId == ua.QuestionId && a.AnswerId == ua.AnswerId));

        // 1. Prepare (QuestionId, AnswerId) pairs from the incoming answers
        //var submittedKeys = answers
        //    .Select(a => new ValueTuple<int, int>(a.QuestionId, a.AnswerId))
        //    .ToList(); // Must be materialized

        //// 2. Query EF with tuple-based Contains
        //var duplicateAnswers = await dbcontext.UserAnswers
        //    .Where(x => submittedKeys
        //        .Contains(new ValueTuple<int, int>(x.QuestionId, x.AnswerId)))
        //    .ToListAsync();


        //if (repeted)
        //    return Result.Failure<List<WrongAnswerResponse>>(new Error("Quiz.Repeted", "You have already submitted this answer.", StatusCodes.Status400BadRequest));
        #endregion

        var questionIds = answers
            .Select(a => a.QuestionId).ToList();

        var questions = await dbcontext.Questions
            .Where(q => questionIds.Contains(q.Id))
            .Include(q => q.Answers)
            .ToListAsync();

        var userAnswers = new List<UserAnswer>();


        foreach (var answerDto in answers)
        {
            var question = questions.FirstOrDefault(q => q.Id == answerDto.QuestionId);
            var selectedAnswer = question?.Answers.FirstOrDefault(a => a.Id == answerDto.AnswerId);

            if (question != null && selectedAnswer != null)
            {
                userAnswers.Add(new UserAnswer
                {
                    UserId = userId,
                    QuestionId = answerDto.QuestionId,
                    AnswerId = answerDto.AnswerId
                });
            }

        }

        // Remove existing answers for this user
        var existingAnswers = await dbcontext.UserAnswers
            .Where(ua => ua.UserId == userId && questionIds.Contains(ua.QuestionId) && !ua.Answer.IsCorrect)
            .ToListAsync();

        dbcontext.UserAnswers.RemoveRange(existingAnswers);
        await dbcontext.SaveChangesAsync(); // Save deletions first


        await dbcontext.UserAnswers.AddRangeAsync(userAnswers);
        await dbcontext.SaveChangesAsync();


        var wrongAnswers = userAnswers
            .Where(ua =>
            {
                var question = questions.First(q => q.Id == ua.QuestionId);
                var selected = question.Answers.First(a => a.Id == ua.AnswerId);
                return !selected.IsCorrect;
            })
            .Select(ua =>
            {
                var question = questions.First(q => q.Id == ua.QuestionId);
                var selected = question.Answers.First(a => a.Id == ua.AnswerId);
                var correct = question.Answers.FirstOrDefault(a => a.IsCorrect);

                return new WrongAnswerResponse
                (
                    question.Id,
                    question.Text,
                    selected.Text,
                    correct?.Text ?? "N/A"
                );
            })
            .ToList();

        int totalAnswers = userAnswers.Count;

        int correctAnswersCount = userAnswers.Count(ua =>
        {
            var question = questions.First(q => q.Id == ua.QuestionId);
            var selected = question.Answers.First(a => a.Id == ua.AnswerId);
            return selected.IsCorrect;
        });

        int wrongAnswersCount = totalAnswers - correctAnswersCount;

        double correctPercentage = totalAnswers == 0 ? 0 : (correctAnswersCount * 100.0) / totalAnswers;
        double wrongPercentage = totalAnswers == 0 ? 0 : (wrongAnswersCount * 100.0) / totalAnswers;

        var ayhaga = new allinone(wrongAnswers, correctPercentage, wrongPercentage);

        return Result.Success(ayhaga);
    }

}
