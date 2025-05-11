﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSpire.Domain.Entity;
public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StangeId { get; set; }
    public Stage Stange{ get; set; } = default!;
    public List<Question> Questions { get; set; } = [];
}
