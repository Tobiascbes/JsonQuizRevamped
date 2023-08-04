using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonQuizRevamped;

internal class QuizLogic
{
    public static void CallQuiz(List<QuizDto> quiz)
    {
        if (!CheckQuiz(quiz))
        {
            return;
        }
        int score = 0;

        foreach (QuizDto quizDto in quiz)
        {
            PrintQuestion(quizDto);
            int userAnswer = AnswerQuestion(quizDto);
            CorrectAnswer(quizDto, userAnswer);
            score += QuizScore(quizDto, userAnswer);
            PrintScore(quiz, score);
        }
    }

    private static bool CheckQuiz(List<QuizDto> quiz)
    {
        //return quiz == null || quiz.Count == 0;

        if (quiz == null || quiz.Count <= 0)
        {
            Console.WriteLine("List is null");
            return false;
        }

        return true;
    }
    private static int QuizCount(List<QuizDto> quiz)
    {
        return quiz.Count;
    }

    private static void PrintQuestion(QuizDto quiz)
    {
        Console.WriteLine(quiz.Question);
        Console.WriteLine($"Answers: {Environment.NewLine}");
        for (int i = 0; i < quiz.Answers!.Length; i++)
        {
            Console.WriteLine($"[{i}]: {quiz.Answers[i]}");
        }
    }
    private static int AnswerQuestion(QuizDto quiz)
    {
        int answer;
        do
        {
            Console.Write("Choice: ");
            answer = CheckAnswer(quiz, Console.ReadLine()!);

            if (answer == -1)
            {
                continue;
            }

            break;

        } while (true);

        return answer;
    }
    private static int CheckAnswer(QuizDto quiz, string answer)
    {
        int answerInt = 0;

        if (!int.TryParse(answer, out answerInt))
        {
            Console.WriteLine("Input isn't an integer");
            return -1;
        }

        if (answerInt > quiz.Answers!.Length)
        {
            Console.WriteLine("Input is above array");
            return -1;
        }

        if (answerInt < 0)
        {
            Console.WriteLine("Input is below 0");
            return -1;
        }
        
        return answerInt;
    }

    private  static void CorrectAnswer(QuizDto quizDto, int answer)
    {
        string status = answer == quizDto.Correct ? "Correct!" : "Incorrect!";
        Console.WriteLine(Environment.NewLine + status + Environment.NewLine + quizDto.Description);
    }
    private static int QuizScore (QuizDto quizDto, int answer)
    {
        return answer == quizDto.Correct ? 1 : 0;
    }

    /*  Could've been an option */
    //private static string GetScore(List<QuizDto> quizDto, int score)
    //{
    //    return $"{score}/{quizDto.Count}";
    //}

    private static void PrintScore(List<QuizDto> quizDtos, int score)
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine($"Score: {score}/{quizDtos.Count}");
    }

}
