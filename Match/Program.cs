int row = 0;

do
{
    if (row == 0 || row >= 25)
        ResetConsole();

    Console.Write("Enter hand of player Black (ex: 2H 3D 5S 9C KD)  ");
    string? blackInput = Console.ReadLine();
    if (string.IsNullOrEmpty(blackInput)) break;

    Console.Write("Enter hand of player White (ex: AH AD 2H 3S 6S)   ");
    string? whiteInput = Console.ReadLine();
    if (string.IsNullOrEmpty(whiteInput)) break;

    Console.WriteLine($"Player Black's input: {blackInput}");
    Console.WriteLine($"Player White's input: {whiteInput}");
    // bool isValid = helperFuncs.validHand(blackInput);
    // isValid = helperFuncs.validHand(whiteInput);
    bool isValid = PokerClass.ValidHand(blackInput);
    isValid = PokerClass.ValidHand(whiteInput);

    if (!isValid)
    {
        Console.WriteLine("********** Invalid hand **********");
        ResetConsole();
        continue;
    }


    // Console.WriteLine("Begins with uppercase? " +
    //         $"{(input.StartsWithUpper() ? "Yes" : "No")}");
    // Console.WriteLine();
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