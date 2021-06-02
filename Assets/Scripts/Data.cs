[System.Serializable]

public class Data 
{
    public int highY;

    public Data(Player chameleon)//sets the data that needs to be saved
    {
        highY = chameleon.highestY;
    }
}
