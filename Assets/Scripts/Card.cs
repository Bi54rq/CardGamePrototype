using UnityEngine;
[System.Serializable] 


public class Card 
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription; 

    
    public Card() 
    {
    
    
    }

    
    public Card(int id, string cardName, int cost, int power, string cardDescription)
    {
        this.id = id;
        this.cardName = cardName;
        this.cost = cost;
        this.power = power;
        this.cardDescription = cardDescription;
    }
}
