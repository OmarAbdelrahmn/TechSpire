using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Application.Contracts.Stage;
public record UserAnswerRequest
([Required(ErrorMessage = "QuestionId is required")]
 int QuestionId,
 [Required(ErrorMessage = "AnswerId is required")]
 int AnswerId
    );
