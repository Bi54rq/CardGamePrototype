using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;  

public class ButtonSceneLoader : MonoBehaviour
{
    [SerializeField] private Button loadMenuButton; 

    void Start()
    {
        
        if (loadMenuButton != null)
        {
            loadMenuButton.onClick.AddListener(LoadMenuScene);
        }
    }

    
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");  
    }
}
