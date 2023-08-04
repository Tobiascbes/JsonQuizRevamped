using JsonQuizRevamped;


internal class Program
{
    static void Main(string[] args)
    {
        QuizLogic.CallQuiz(JsonHandler.GetQuizDtos());
    }
}