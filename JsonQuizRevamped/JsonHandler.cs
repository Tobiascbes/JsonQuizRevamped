using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonQuizRevamped;

internal class JsonHandler
{
    private static string JsonFile = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory() + "\\quiz.json"));

    public static List<QuizDto> GetQuizDtos()
    {
        return JsonConvert.DeserializeObject<List<QuizDto>>(JsonFile)!;
    }
}
