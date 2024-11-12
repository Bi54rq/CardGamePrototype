using UnityEngine;
using System.Collections.Generic;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public int x;
    public int deckSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x = 0;
        
        for(int i = 0; i < 10; i++)
        {
            x = Random.Range(1, 5);
            deck[i] = CardDatabase.cardList[x];

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];

        }

    }


}