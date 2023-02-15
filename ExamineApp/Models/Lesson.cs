using System;
using System.Collections.Generic;

namespace ExamineApp.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public decimal? ClassNum { get; set; }

    public string? TeacherName { get; set; }

    public string? TeacherSurName { get; set; }
}
