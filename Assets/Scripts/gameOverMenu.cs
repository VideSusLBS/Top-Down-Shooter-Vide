using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void tryAgain()
    {
        SceneManager.LoadScene("Spel");
    }
}
