using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Application.Contracts.Stage;
public record LessonResponse
(
    int Id,
    string Title,
    string Content
    );
