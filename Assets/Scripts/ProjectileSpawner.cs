using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Le prefab de projectile à lancer
    [SerializeField] private float spawnIntervalMin = 1f; // Intervalle minimum pour spawner un projectile
    [SerializeField] private float spawnIntervalMax = 3f; // Intervalle maximum pour spawner un projectile
    [SerializeField] private float spawnHeight = 5f; // Hauteur à laquelle les projectiles apparaîtront

    private void Start()
    {
        // Commence à spawn des projectiles à des intervalles aléatoires
        InvokeRepeating("SpawnProjectile", Random.Range(spawnIntervalMin, spawnIntervalMax), Random.Range(spawnIntervalMin, spawnIntervalMax));
    }

    private void SpawnProjectile()
    {
        // Vérifie si le prefab du projectile est bien assigné
        if (projectilePrefab != null)
        {
            // Créer un projectile à une position aléatoire dans l'axe X (sur la largeur de la scène) et à une hauteur fixe
            Vector3 spawnPosition = new Vector3(10f, Random.Range(-spawnHeight, spawnHeight), 0f);
            Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Le prefab du projectile n'est pas assigné dans l'inspecteur !");
        }
    }

}