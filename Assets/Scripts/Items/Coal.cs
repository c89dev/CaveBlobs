namespace Items
{

    public class Coal : Ore

    {
    public int OreFuel { get; private set; }

    private System.Random _random = new System.Random();


    public Coal(string oreType, int oreValue, int oreFuel)
    {
        OreType = "Coal";
        OreValue = oreValue;
        OreFuel = oreFuel;
    }
    }
}