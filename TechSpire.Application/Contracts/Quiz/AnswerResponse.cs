using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Application.Contracts.Quiz;
public record AnswerResponse
(
    int Id,
    string Text
   // bool IsCorrect
    );
