using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Application.Contracts.Stage;
public record BookResponse
(
    int Id,
    string Title,
    string Description,
    string ImageUrl,
    string BookUrl
    );
