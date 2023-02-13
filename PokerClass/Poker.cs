public static class PokerClass
{
    public static bool ValidHand(string hand)
    {
        string[] splittedHand = hand.Split(" ");
        
        if (splittedHand.Length != 5)
            return false;
        
        return true;
    }
    public static string GetHandRank(string hand)
    {
        return "Ranking";
    }
}