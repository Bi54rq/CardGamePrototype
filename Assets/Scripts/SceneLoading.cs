using UnityEngine;
using UnityEngine.SceneManagement;  // Required to load scenes

public class SceneLoading : MonoBehaviour
{
    // This method will be used to load a scene by name
    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");  // Loads the "Victory" scene
    }
}
