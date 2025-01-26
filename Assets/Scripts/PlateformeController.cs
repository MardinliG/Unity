using System;
using UnityEngine;

public class PlateformeController : MonoBehaviour
{
    public Transform posA, posB; // Points entre lesquels la plateforme oscille
    public float speed; // Vitesse de déplacement de la plateforme
    private Vector2 targetPos; // Position cible actuelle de la plateforme
    private Vector3 originalPlayerScale; // Stocke l'échelle initiale du joueur

    void Start()
    {
        targetPos = posB.position; // La plateforme commence à se diriger vers posB
    }

    void Update()
    {
        // Change la position cible lorsque la plateforme atteint l'un des points
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            targetPos = posB.position;
        }
        else if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            targetPos = posA.position;
        }

        // Déplace la plateforme vers la position cible
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}