using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> buttons = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    public Text turnText; // Reference to the UI Text element showing whose turn it is
    public Text player1ScoreText; // Reference to the UI Text element showing Player 1's score
    public Text player2ScoreText; // Reference to the UI Text element showing Player 2's score
    public Text winnerText; // Reference to the UI Text element showing the winner

    private int currentPlayer = 1; // 1 = Player 1, 2 = Player 2

    private int player1Score = 0; // Score for Player 1
    private int player2Score = 0; // Score for Player 2

    // Reference to the SceneLoader to load scenes
    public SceneLoading sceneLoading;

    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Button");
    }

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2; // Number of guesses in the game

        UpdateTurnText(); // Display the first player's turn
        UpdateScores(); // Initialize the scores display
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            buttons.Add(objects[i].GetComponent<Button>());
            buttons[i].image.sprite = bgImage;  // Set initial background image
        }
    }

    void AddGamePuzzles()
    {
        int looper = buttons.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);

            index++;
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

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            buttons[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

            // Disable only the first button after it's clicked
            buttons[firstGuessIndex].interactable = false;
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            buttons[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            // Disable the second button after it's clicked
            buttons[secondGuessIndex].interactable = false;

            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch()
    {
        // Give the player a moment to see the second guess
        yield return new WaitForSeconds(1f);

        // Disable the buttons' interactivity during match checking
        buttons[firstGuessIndex].interactable = false;
        buttons[secondGuessIndex].interactable = false;

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.5f);
            // If they match, hide the images
            buttons[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            buttons[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            // Update the score for the current player
            if (currentPlayer == 1)
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }

            // Update the score UI
            UpdateScores();

            // Check if the game is finished
            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            // Reset the images and re-enable the buttons for another guess
            buttons[firstGuessIndex].image.sprite = bgImage;
            buttons[secondGuessIndex].image.sprite = bgImage;

            // Reset interactivity for the next pair of guesses
            buttons[firstGuessIndex].interactable = true;
            buttons[secondGuessIndex].interactable = true;

            // Switch turns after a wrong guess
            SwitchTurn();
        }

        // Reset the guess flags
        firstGuess = secondGuess = false;
    }

    void SwitchTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1; // Toggle between Player 1 and Player 2
        UpdateTurnText();
    }

    void UpdateTurnText()
    {
        turnText.text = "Player " + currentPlayer + "'s Turn"; // Update UI text to show current player
    }

    void UpdateScores()
    {
        player1ScoreText.text = "Player 1: " + player1Score; // Update Player 1's score
        player2ScoreText.text = "Player 2: " + player2Score; // Update Player 2's score
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Game Finished");
            // Determine the winner based on the scores
            string winner = player1Score > player2Score ? "Player 1" : (player2Score > player1Score ? "Player 2" : "Draw");

            // Call the LoadVictoryScene() method with the winner's name
            sceneLoading.LoadVictoryScene(winner);

            Debug.Log("It took you " + countGuesses + " guess(es) to finish");
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
