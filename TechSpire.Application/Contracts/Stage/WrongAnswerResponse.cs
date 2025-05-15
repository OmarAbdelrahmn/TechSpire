using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Application.Contracts.Stage;
public record WrongAnswerResponse
(
    int QustionId,
    string Text,
    List<string> SelectedAnswerText,
    List<string> CorrectAnswerText,
    double QuestionScore
    );


public record Allinone(
    
    List<WrongAnswerResponse> WrongAnswers,
    double Success ,
    double Failed
    );