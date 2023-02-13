namespace PokerTest;

[TestClass]
public class PokerTestFirst
{
    [TestMethod]
    public void TestBothFlush()
    {  
        string blackHand = "2H 4S 4C 3D 4H";
        string whiteHand = "2S 8S AS QS 3S";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

         if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);

        Assert.AreEqual("White", result.winner, "White wins");
    }
    [TestMethod]
    public void TestWrongFlush(){
        string whiteHand = "2H 4S 4C 3D 4H";
        string blackHand = "2S 8S AS QS 3S";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is not valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);

        Assert.AreNotEqual("White", result.winner, "Black has the flush!");
    }

    [TestMethod]
    public void TestInvalidHand(){
        string whiteHand = "2H 4S 4C 3D 4H";
        string blackHand = "2S8S AS QS 3S";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsFalse(isValidHand, "Black's hand is not valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");
    }
}
