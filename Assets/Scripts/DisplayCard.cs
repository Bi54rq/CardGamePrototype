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

    void Start()
    {
        // Check if displayId is valid
        if (displayId >= 0 && displayId < CardDatabase.cardList.Count)
        {
            UpdateCardDisplay(CardDatabase.cardList[displayId]);
        }
        else
        {
            Debug.LogError("Display ID is out of range.");
        }
    }

    void UpdateCardDisplay(Card card)
    {
        nameText.text = card.cardName;
        costText.text = card.cost.ToString();
        powerText.text = card.power.ToString();
        descriptionText.text = card.cardDescription;
    }
}
