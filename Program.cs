using System;
using System.Linq;

PrintParagraph("IELTS score average FOR academic");

PrintText("Listening score: ");
decimal listeningScore = GetUserScore();

PrintText("Reading score: ");
decimal readingScore = GetUserScore();

PrintText("Speaking score: ");
decimal speakingScore = GetUserScore();

PrintText("Writing score: ");
decimal writingScore = GetUserScore();

decimal[] scores = new decimal[] { speakingScore, listeningScore, writingScore, readingScore };

decimal averageScore = scores.Average();
int baseScore = (int)averageScore;
decimal remainder = ExtractRemainder(averageScore);

averageScore = baseScore + remainder;
string levelName = MapToLevelName(averageScore);
PrintParagraph($"Your overall : {averageScore}!\nYour Category: {levelName}");

void PrintParagraph(string message)
{
    Console.WriteLine(message);
}

void PrintText(string message)
{
    Console.Write(message);
}

string MapToLevelName(decimal score)
{
    return score switch
    {
        9 or 8.5m => "Expert",
        8 or 7.5m => "Very Good",
        7 or 6.5m => "Good",
        6 or 5.5m => "Competent",
        5 => "Modest",
        _ =>"Incompetent"
    };
}

decimal ExtractRemainder(decimal averageScore)
{
    decimal rawRemainder = averageScore - (int)averageScore;
    
    return rawRemainder switch
    {
        < 0.25m => 0,
        < 0.75m => 0.5m,
        _ => 1,
    };
}

decimal GetUserScore()
{
    string userInput = Console.ReadLine();

    try
    {
        return Convert.ToDecimal(userInput);
    }
    catch(FormatException formatException)
    {
        Console.WriteLine("The score you inserted was invalid. Considering this section 0...");
        return 0;
    }
}