using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Charge la scène "MainMenu"
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}