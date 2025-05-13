using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechSpire.Domain.Entities;

namespace TechSpire.Application.Contracts.Quiz;
public record QuizResponse
(   int Id,
    string Title ,
    string Description,
    int StangeId,
    List<QuestionResponse> Questions);
