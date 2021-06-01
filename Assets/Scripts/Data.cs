[System.Serializable]

public class Data 
{
    public int highY;

    public Data(Player chameleon)
    {
        highY = chameleon.highestY;
    }
}
