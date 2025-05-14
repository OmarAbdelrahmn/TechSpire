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
    string SelectedAnswerText,
    string CorrectAnswerText
    );


public record allinone(
    
    List<WrongAnswerResponse> WrongAnswers,
    double Success ,
    double Failed
    );