using UnityEngine;
using UnityEngine.SceneManagement;  // Required to load scenes

public class SceneLoading : MonoBehaviour
{
    // This method will load a scene based on the winner
    public void LoadVictoryScene(string winner)
    {
        if (winner == "Player 1")
        {
            SceneManager.LoadScene("P1Winner");  // Loads the "P1Winner" scene
        }
        else if (winner == "Player 2")
        {
            SceneManager.LoadScene("P2Winner");  // Loads the "P2Winner" scene
        }
        else
        {
            // If there's a draw, you can load a draw scene (optional)
            SceneManager.LoadScene("Draw");  // Loads a "Draw" scene (if needed)
        }
    }
}
