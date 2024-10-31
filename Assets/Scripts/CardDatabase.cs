using System.Collections.Generic; // Add this line
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None"));
        cardList.Add(new Card(1, "Lizard", 3, 2, "Dis a Lizard"));
        cardList.Add(new Card(2, "Dog", 2, 1, "Dog"));
        cardList.Add(new Card(3, "Monkey", 1, 3, "Monkeh"));
        cardList.Add(new Card(5, "Dragon", 5, 5, "Dargon"));





    }











}
