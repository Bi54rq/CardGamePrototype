using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button loadSceneButton; // Reference to the button
    public string sceneName; // Name of the scene to load

    private void Start()
    {
        if (loadSceneButton != null)
        {
            loadSceneButton.onClick.AddListener(LoadScene);
        }
        else
        {
            Debug.LogError("Load Scene Button is not assigned!");
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName); // Load the specified scene
    }
}
