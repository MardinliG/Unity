using UnityEngine;

public class CollectibleOrb : MonoBehaviour
{
    // Détecte quand un objet entre en contact avec l'orbe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet qui entre est le joueur
        if (collision.CompareTag("Player"))
        {
            // Signale au LevelManager qu'une orbe a été collectée
            LevelManager.Instance.CollectOrb();

            // Détruit l'orbe après sa collecte
            Destroy(gameObject);
        }
    }
}
