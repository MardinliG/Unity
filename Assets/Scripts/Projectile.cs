using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Vitesse du projectile
    [SerializeField] private float lifetime = 5f; // Durée de vie du projectile avant qu'il disparaisse

    private void Start()
    {
        // Lancer le projectile uniquement vers la gauche
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed; // Utiliser velocity plutôt que linearVelocity

        // Détruire le projectile après une certaine durée pour éviter qu'il ne reste dans la scène
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifier si le projectile touche le joueur
        if (other.CompareTag("Player"))
        {
            // Appeler la méthode GameOver dans le LevelManager
            LevelManager.Instance.GameOver();
            Destroy(gameObject); // Détruire le projectile après avoir touché le joueur
        }
    }
}