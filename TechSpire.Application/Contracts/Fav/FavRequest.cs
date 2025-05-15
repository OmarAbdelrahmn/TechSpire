using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Application.Contracts.Fav;
public record FavRequest
(
    [Required(ErrorMessage ="Type is required")]
    string Type,
    [Required(ErrorMessage ="ItemId is required")]
    int ItemId
    );
