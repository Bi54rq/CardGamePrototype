using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Needed for List<T>

public class DisplayCard : MonoBehaviour
{
    public int displayId; // Set this in the inspector or elsewhere in the code
    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;
    public Image artImage; // This should be a UI Image to display the sprite

    public bool cardBack;
    public static bool staticCardBack;

    void Start()
    {
        // Check if displayId is valid
        if (displayId >= 0 && displayId < CardDatabase.cardList.Count)
        {
            // Get the card from the CardDatabase
            Card card = CardDatabase.cardList[displayId];

            // Update the card display information
            UpdateCardDisplay(card);

            // Assign the sprite to the artImage if it's not null
            if (card.spriteImage != null && artImage != null)
            {
                artImage.sprite = card.spriteImage;
            }
            else
            {
                Debug.LogError("Card image is missing or artImage is not assigned.");
            }
        }
        else
        {
            Debug.LogError("Display ID is out of range.");
        }
    }
    void Update()
    {
        staticCardBack = cardBack;
    }

    void UpdateCardDisplay(Card card)
    {
        nameText.text = card.cardName;
        costText.text = card.cost.ToString();
        powerText.text = card.power.ToString();
        descriptionText.text = card.cardDescription;
    }
}
