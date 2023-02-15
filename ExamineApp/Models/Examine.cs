using System;
using System.Collections.Generic;

namespace ExamineApp.Models;

public partial class Examine
{
    public int Id { get; set; }

    public string? LessonCode { get; set; }

    public decimal? PupilNumber { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Result { get; set; }
}
