[System.Serializable]

public class Item 
{
    public string name;
    public int count;

    public Item(string itemName, int itemCount)
    {
        //CONSTRUCTOR WITH ITEM NAME AND COUNT
        name = itemName;
        count = itemCount;
    }


}
