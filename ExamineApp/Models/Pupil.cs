using System;
using System.Collections.Generic;

namespace ExamineApp.Models;

public partial class Pupil
{
    public int Id { get; set; }

    public decimal? Number { get; set; }

    public string? Name { get; set; }

    public string? SurName { get; set; }

    public decimal? ClassNum { get; set; }
}
