using System.Linq;
public static class PokerClass
{
    const string FLUSH = "FLUSH";
    public static bool ValidHand(string hand)
    {
        string[] splittedHand = hand.Split(" ");
        
        if (splittedHand.Length != 5)
            return false;
        
        foreach (string card in splittedHand){
            if (card.Length != 2)
                return false;
            if (!"23456789TJQKA".Contains(card[0]))
                return false;
            if (!"CDHS".Contains(card[1]))
                return false;
        }

        return true;
    }
    public static (string winner, string reason) GetHandRanks(string blackInput, string whiteInput)
    {
        string[] blackHand = blackInput.Split(" ");
        string[] whiteHand = whiteInput.Split(" ");

        string blackRank = GetRank(blackHand);
        string whiteRank = GetRank(whiteHand);

        if (blackRank == FLUSH && whiteRank == FLUSH)
        {
            // compare the highest card
            GetHighestCard(blackHand, whiteHand);
            
        }else if (blackRank == FLUSH)
        {
            return (winner: "Black", reason: "Flush");
        } else if (whiteRank == FLUSH)
        {
            return (winner: "White", reason: "Flush");
        }

        return (winner: "Tie", reason: "Tie");
    }

    private static string GetRank(string[] hand)
    {   
        bool isFlush = true;
        // check for flush
        foreach (string card in hand)
        {  
           if (card[1] != hand[0][1])
           {
                isFlush = false;
                break;
           }
        }

        if (isFlush)
        {
            return FLUSH;
        }

        


        // Check for Royal Flush

        // Check for Straight Flush
        // Check for Four of a Kind
        // Check for Full House
        // Check for Flush
        // Check for Straight
        // Check for Three of a Kind
        // Check for Two Pair
        // Check for One Pair
        // Check for High Card
        return "Ranking";
    }

    private static string GetHighestCard(string[] blackHand, string[] whiteHand)
    {   
        string blackHighestCard = blackHand[0];
        
        // get the highest card
        string blackHighestCardStr = blackHand[0][0].ToString();
        int blackHighestCardInt = 0;
        foreach (string card in blackHand)
        {
            if(blackHighestCardStr == "A") blackHighestCardInt = 14;
            if(blackHighestCardStr == "K") blackHighestCardInt = 13;
            if(blackHighestCardStr == "Q") blackHighestCardInt = 12;
            if(blackHighestCardStr == "J") blackHighestCardInt = 11;

            blackHighestCardInt = Int32.Parse(blackHighestCardStr);
            
            int cardValueInt = 0;
            if(card[0] == 'A') cardValueInt = 14;
            if (card[0] == 'K') cardValueInt = 13;
            if (card[0] == 'Q') cardValueInt = 12;
            if (card[0] == 'J') cardValueInt = 11;

            cardValueInt = Int32.Parse(card[0].ToString());

            if (cardValueInt > blackHighestCardInt)
                blackHighestCard = card;
        }
        string whiteHighestCard = whiteHand[0];
        
        string whiteHighestCardStr = whiteHand[0][0].ToString();
        int whiteHighestCardInt = 0;
        foreach (string card in whiteHand)
        {
            if(whiteHighestCardStr == "A") whiteHighestCardInt = 14;
            if(whiteHighestCardStr == "K") whiteHighestCardInt = 13;
            if(whiteHighestCardStr == "Q") whiteHighestCardInt = 12;
            if(whiteHighestCardStr == "J") whiteHighestCardInt = 11;

            whiteHighestCardInt = Int32.Parse(whiteHighestCardStr);
            
            int cardValueInt = 0;
            if(card[0] == 'A') cardValueInt = 14;
            if (card[0] == 'K') cardValueInt = 13;
            if (card[0] == 'Q') cardValueInt = 12;
            if (card[0] == 'J') cardValueInt = 11;

            cardValueInt = Int32.Parse(card[0].ToString());

            if (cardValueInt > whiteHighestCardInt)
                whiteHighestCard = card;
        }
        // compare the highest card
        if (blackHighestCardInt > whiteHighestCardInt)
            return "Black";
        else return "White";
    }
}