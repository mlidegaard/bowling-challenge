using bowling_challenge.Models;

Console.WriteLine("Hej og velkommen til bowling simuleringen!");
Console.WriteLine("Du indleder nu et spil bowling der består af 10 runder.");
Console.WriteLine();
Console.WriteLine("Du bedes for hver runde indtaste antal kegler du ønsker at vælte. Tallet skal være mellem 0 og 10.");

BowlingGame bowlingGame = new BowlingGame();

while (bowlingGame.CanContinueToNextFrame)
{
    Console.WriteLine($"Du er i runde {bowlingGame.FrameNumber}");
    Console.WriteLine("Indtast antal kegler du ønsker at vælte...");

    var successfullyParsedKnockedPins = Int32.TryParse(Console.ReadLine(), out var knockedPins);

    if (successfullyParsedKnockedPins)
    {
        bowlingGame.RollBall(knockedPins);

        var score = bowlingGame.GetScore();
        Console.WriteLine($"Nuværende score: {score}");
        Console.WriteLine("------------------------------------");
    }
    else
    {
        Console.WriteLine($"Indtast et helt tal mellem 0 og 10.");
    }
}

Console.WriteLine("Dit spil er afsluttet. Genstart applikationen for at prøve igen.");
Console.ReadLine();
