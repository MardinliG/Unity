using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int totalOrbs = 8; // Nombre d'orbes à collecter
    private int collectedOrbs = 0;

    [SerializeField] private Timer timer; // Référence au script Timer

    private void Awake()
    {
        Instance = this; // Singleton
    }

    private void Update()
    {
        // Vérifier si le timer est à 0 et que toutes les orbes n'ont pas été collectées
        if (timer.remainingTime <= 0 && collectedOrbs < totalOrbs)
        {
            GameOver();
        }
    }

    public void CollectOrb()
    {
        collectedOrbs++;
        Debug.Log($"Orbes collectées : {collectedOrbs}/{totalOrbs}");

        // Si toutes les orbes sont collectées avant la fin du temps
        if (collectedOrbs >= totalOrbs)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        Debug.Log("Niveau terminé !");
        // Charger la prochaine scène ou afficher un écran de fin
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        Debug.Log("Temps écoulé ! Vous avez perdu.");
        // Gérer la fin du jeu (recommencer la scène ou autre logique de perte)
        // Exemple: Recommencer la scène actuelle
        SceneManager.LoadSceneAsync(4);
    }
}