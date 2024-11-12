using System.Collections.Generic; // Add this line
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        // Initialize cards with default sprites (check for null values after loading)
        cardList.Add(new Card(0, "None", 0, 0, "None", null)); // Provide null for cards with no image
        cardList.Add(new Card(1, "Lizard", 3, 2, "Dis a Lizard", LoadSprite("lizardimage")));
        cardList.Add(new Card(2, "Dog", 2, 1, "Dog", LoadSprite("dogimage")));
        cardList.Add(new Card(3, "Monkey", 1, 3, "Monkeh", LoadSprite("monkeyimage")));
        cardList.Add(new Card(4, "Dragon", 5, 5, "Dargon", LoadSprite("dragonimage")));
    }

    // Helper function to load a sprite from Resources folder
    Sprite LoadSprite(string imageName)
    {
        Sprite sprite = Resources.Load<Sprite>(imageName);
        if (sprite == null)
        {
            Debug.LogError($"Error: Sprite '{imageName}' not found in Resources folder.");
        }
        return sprite;
    }
}
