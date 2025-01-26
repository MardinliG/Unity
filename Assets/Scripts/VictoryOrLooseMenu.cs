using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryOrLooseMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
