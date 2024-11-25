using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;  // Fixed the typo here

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;



    public List<Button> buttons = new List<Button>();

    void Start()
    {
        
        GetButtons();
        AddListeners();
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");  // Renamed variable to objects

        for (int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = bgImage;
        }
    }

    void AddListeners()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Button named " + name);
    }

}
