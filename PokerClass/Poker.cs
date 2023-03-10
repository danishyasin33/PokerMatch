using System.Linq;
public static class PokerClass
{
    const string FLUSH = "FLUSH";
    const string ONE_PAIR = "ONE_PAIR";
    const string TWO_PAIR = "TWO_PAIR";
    const string THREE_OF_A_KIND = "THREE_OF_A_KIND";
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

        var blackRank = GetRank(blackHand);
        var whiteRank = GetRank(whiteHand);

        if (blackRank.rank == FLUSH && whiteRank.rank == FLUSH)
        {
            // compare the highest card
            string winner = GetHighestCard(blackHand, whiteHand, FLUSH);
            if(winner == "Tie"){
                return (winner: "None", reason: "Flush with Tie");
            }else{
                return (winner: winner, reason: "Flush with highest card");
            }
            
        }else if (blackRank.rank == FLUSH)
        {
            return (winner: "Black", reason: "Flush");
        } else if (whiteRank.rank == FLUSH)
        {
            return (winner: "White", reason: "Flush");
        }

        if (blackRank.rank == ONE_PAIR && blackRank.rankValue > whiteRank.rankValue)
        {
            return (winner: "Black", reason: "One pair");
        } else if (whiteRank.rank == ONE_PAIR && whiteRank.rankValue > blackRank.rankValue)
        {
            return (winner: "White", reason: "One pair");
        }
        if (blackRank.rank == ONE_PAIR && whiteRank.rank == ONE_PAIR)
        {
            if (blackRank.pairs[0] > whiteRank.pairs[0])
                return (winner: "Black", reason: "One Pair Greater than White");

            if (blackRank.pairs[0] < whiteRank.pairs[0])
                return (winner: "White", reason: "One pair Greater than Black");
        }

        if (blackRank.rank == TWO_PAIR && blackRank.rankValue > whiteRank.rankValue)
        {
            return (winner: "Black", reason: "Two pairs");
        } else if (whiteRank.rank == TWO_PAIR && whiteRank.rankValue > blackRank.rankValue)
        {
            return (winner: "White", reason: "Two pairs");
        }
        if (blackRank.rank == TWO_PAIR && whiteRank.rank == TWO_PAIR)
        {
            int blackHighestPairVal = blackRank.pairs.Max();
            int whiteHighestPairVal = whiteRank.pairs.Max();

            if (blackHighestPairVal > whiteHighestPairVal)
                return (winner: "Black", reason: "Two pairs Greater than White");
            
            if (blackHighestPairVal < whiteHighestPairVal)
                return (winner: "White", reason: "Two pairs Greater than Black");
        }

        if (blackRank.rank == THREE_OF_A_KIND && blackRank.rankValue > whiteRank.rankValue)
        {
            return (winner: "Black", reason: "Three of a kind");
        } else if (whiteRank.rank == THREE_OF_A_KIND && whiteRank.rankValue > blackRank.rankValue)
        {
            return (winner: "White", reason: "Three of a kind");
        }
        if (blackRank.rank == THREE_OF_A_KIND && whiteRank.rank == THREE_OF_A_KIND)
        {
            if (blackRank.pairs[0] > whiteRank.pairs[0])
                return (winner: "Black", reason: "Three of a Kind Greater than White");

            if (blackRank.pairs[0] < whiteRank.pairs[0])
                return (winner: "White", reason: "Three of a Kind Greater than Black");
        }

        // compare the highest card
        string winnerEnd = GetHighestCard(blackHand, whiteHand);
        if(winnerEnd == "Tie"){
            return (winner: "None", reason: "Tie");
        }else{
            return (winner: winnerEnd, reason: "Highest card");
        }   
    }

    // Ranking
    // 5 Flush
    // 4 Three of a kind
    // 3 Two pairs
    // 2 One pair
    // 1 High card
    private static (string rank, string? meta, int[]? pairs, int rankValue) GetRank(string[] hand)
    {   
        bool isFlush = true;
        foreach (string card in hand)
        {   
            // check for flush
           if (card[1] != hand[0][1])
           {
                isFlush = false;
                break;
           }
        }
        if (isFlush)
            return (FLUSH,hand[0][1].ToString(), new int[0], 5);

        // numerize hand 
        int[] handValues = new int[5]; 
        int index = 0;
        foreach (string card in hand)
        {
            char firstVal = card[0];
            if(card[0] == 'A') {handValues[index] = 14; continue;}
            if(card[0] == 'K') {handValues[index] = 13; continue;}
            if(card[0] == 'Q') {handValues[index] = 12; continue;}
            if(card[0] == 'J') {handValues[index] = 11; continue;}

            handValues[index] = Int32.Parse(card[0].ToString());
            index++;
        }

        Array.Sort(handValues);
        // max vals we'll have is 2 unique pairs;
        int[] pairsOf = new int[2];

        // check for three of a kind
        for (int i = 0; i < handValues.Length - 1; i++)
        {
            if(i+2 >= handValues.Length || i+1 >= handValues.Length){
                break;
            }
            if (handValues[i] == handValues[i + 1] && handValues[i] == handValues[i + 2])
            {
                pairsOf[0] = handValues[i];
                return (THREE_OF_A_KIND, "", pairsOf, 4);
            }
        }

        int pairsCount = 0;
        for (int i = 0; i < handValues.Length - 1; i++)
        {
            if (i + 1 >= handValues.Length)
            {
                break;
            }
            if (handValues[i] == handValues[i + 1])
            {
                pairsOf[pairsCount] = handValues[i];
                pairsCount++;
            }
        }

        if (pairsCount == 1)
            return (ONE_PAIR, "", pairsOf, 2);
        if (pairsCount == 2)
            return (TWO_PAIR, "", pairsOf, 3);

        return ("Undefined", "", null, 1);
    }

    private static string GetHighestCard(string[] blackHand, string[] whiteHand, string rank = "")
    {   
        // get the highest card
        string blackHighestCardStr = blackHand[0][0].ToString();
        int blackHighestCardInt = 0;
        foreach (string card in blackHand)
        {
            if(blackHighestCardStr == "A") blackHighestCardInt = 14;
            else if(blackHighestCardStr == "K") blackHighestCardInt = 13;
            else if(blackHighestCardStr == "Q") blackHighestCardInt = 12;
            else if(blackHighestCardStr == "J") blackHighestCardInt = 11;
            else blackHighestCardInt = Int32.Parse(blackHighestCardStr);
            
            int cardValueInt = 0;
            if(card[0] == 'A') cardValueInt = 14;
            else if (card[0] == 'K') cardValueInt = 13;
            else if (card[0] == 'Q') cardValueInt = 12;
            else if (card[0] == 'J') cardValueInt = 11;
            else cardValueInt = Int32.Parse(card[0].ToString());

            if (cardValueInt > blackHighestCardInt)
                blackHighestCardInt = cardValueInt;
        }
        
        string whiteHighestCardStr = whiteHand[0][0].ToString();
        int whiteHighestCardInt = 0;
        foreach (string card in whiteHand)
        {
            if(whiteHighestCardStr == "A") whiteHighestCardInt = 14;
            else if(whiteHighestCardStr == "K") whiteHighestCardInt = 13;
            else if(whiteHighestCardStr == "Q") whiteHighestCardInt = 12;
            else if(whiteHighestCardStr == "J") whiteHighestCardInt = 11;
            else whiteHighestCardInt = Int32.Parse(whiteHighestCardStr);
            
            int cardValueInt = 0;
            if(card[0] == 'A') cardValueInt = 14;
            else if (card[0] == 'K') cardValueInt = 13;
            else if (card[0] == 'Q') cardValueInt = 12;
            else if (card[0] == 'J') cardValueInt = 11;
            else cardValueInt = Int32.Parse(card[0].ToString());

            if (cardValueInt > whiteHighestCardInt)
                whiteHighestCardInt = cardValueInt;
        }
        // compare the highest card
        if (blackHighestCardInt > whiteHighestCardInt)
            return "Black";
        else if(whiteHighestCardInt > blackHighestCardInt) return "White";
        else return "Tie";
    }
}