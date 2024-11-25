using UnityEngine;
using System.Collections;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject buttonPrefab;  // Renamed to avoid confusion

    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab);  // Use a new variable for the instantiated button
            buttonInstance.name = "" + i;
            buttonInstance.transform.SetParent(puzzleField, false);
        }
    }
}
