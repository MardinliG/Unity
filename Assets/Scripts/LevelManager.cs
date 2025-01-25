using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int totalOrbs = 8; // Nombre d'orbes à collecter
    private int collectedOrbs = 0;

    private void Awake()
    {
        Instance = this; // Singleton
    }

    public void CollectOrb()
    {
        collectedOrbs++;
        Debug.Log($"Orbes collectées : {collectedOrbs}/{totalOrbs}");
        if (collectedOrbs >= totalOrbs)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        Debug.Log("Niveau terminé !");
        // Charger la prochaine scène ou afficher un écran de fin
        SceneManager.LoadSceneAsync(0);
    }
} 