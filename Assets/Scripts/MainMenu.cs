using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Spel");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
