using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed; // Vitesse de déplacement
    private float currentPosX; // Position actuelle de la caméra
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }
    
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
