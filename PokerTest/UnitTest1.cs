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
    [TestMethod]
    public void TestThreeOfKind(){
        string whiteHand = "2H 4S 4C 3D 4H";
        string blackHand = "2S 8S AS QH 3S";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);
        Assert.AreEqual("White", result.winner, "White wins");
        Assert.AreEqual("Three of a kind", result.reason, "White wins");
    }
    [TestMethod]
    public void TestOnePair(){
        string whiteHand = "2H 4S 4C 3D 6H";
        string blackHand = "2H 3D 5S 9C KD";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);
        Assert.AreEqual("White", result.winner, "White wins");
        Assert.AreEqual("One pair", result.reason, "White wins");
    }
    [TestMethod]
    public void TestBothOnePair(){
        string whiteHand = "2H 4S 4C 3D 6H";
        string blackHand = "2H 3D 5S 3C KD";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);
        Assert.AreEqual("White", result.winner, "White wins");
        Assert.AreEqual("One pair Greater than Black", result.reason, "White wins");
    }
    [TestMethod]
    public void TestTwoPairs(){
        string whiteHand = "2H 4S 4C 3D 2H";
        string blackHand = "2S 8S AS QH 3S";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);
        Assert.AreEqual("White", result.winner, "White wins");
        Assert.AreEqual("Two pairs", result.reason, "White wins");
    }
    [TestMethod]
    public void TestBothTwoPairs(){
        string whiteHand = "2H 4S 4C 3D 2H";
        string blackHand = "AS 8S 8S AH 3S";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);
        Assert.AreEqual("Black", result.winner, "Black wins");
        Assert.AreEqual("Two pairs Greater than White", result.reason, "Black wins");
    }
    [TestMethod]
    public void TestTie(){
        string whiteHand = "2H 4S 4C 3D 2H";
        string blackHand = "2S 4S 4C 3D 2H";

        bool isValidHand = PokerClass.ValidHand(blackHand);
        Assert.IsTrue(isValidHand, "Black's hand is valid");
        isValidHand = PokerClass.ValidHand(whiteHand);
        Assert.IsTrue(isValidHand, "White's hand is valid");

        if(!isValidHand)
            return;

        var result = PokerClass.GetHandRanks(blackHand, whiteHand);
        Assert.AreEqual("None", result.winner, "Tie");
        Assert.AreEqual("Tie", result.reason, "Tie");
    }
}
