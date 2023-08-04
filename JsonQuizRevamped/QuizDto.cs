using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuizRevamped;

internal class QuizDto
{
    public string? Question { get; set; }
    public string[]? Answers { get; set; }
    public string? Description { get; set; }
    public int Correct { get; set; }

}
