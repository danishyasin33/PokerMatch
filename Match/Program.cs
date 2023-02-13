﻿int row = 0;

do
{
    if (row == 0 || row >= 25)
        ResetConsole();

    // Console.Write("Enter hand of player Black (ex: 2H 3D 5S 9C KD)  ");
    // string? blackInput = Console.ReadLine();
    // if (string.IsNullOrEmpty(blackInput)) break;

    // Console.Write("Enter hand of player White (ex: AH AD 2H 3S 6S)   ");
    // string? whiteInput = Console.ReadLine();
    // if (string.IsNullOrEmpty(whiteInput)) break;

    string? blackInput = "2S 8S AS QS 3S";
    string? whiteInput = "2H 4S 4C 3D 4H";

    Console.WriteLine($"\n\nPlayer Black's input: {blackInput}");
    Console.WriteLine($"Player White's input: {whiteInput}");

    bool isValid = PokerClass.ValidHand(blackInput);
    isValid = PokerClass.ValidHand(whiteInput);

    if (!isValid)
    {
        Console.WriteLine("\n\n********** Invalid hand **********");
        ResetConsole();
        continue;
    }

    var result = PokerClass.GetHandRanks(blackInput, whiteInput);
    Console.WriteLine($"\n\nThe winner is: {result.winner}; reason: {result.reason}");
    row += 4;
} while (true);
return;

// Declare a ResetConsole local method
void ResetConsole()
{
    if (row > 0)
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    Console.Clear();
    Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press <Enter>:{Environment.NewLine}");
    row = 3;
}