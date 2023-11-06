using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public float smoothTime = 0.3f; // Suavidad del seguimiento de la c�mara
    private Vector3 velocity = Vector3.zero;
    private bool isPlayerAlive = true; // Bandera para verificar si el jugador est� vivo

    void LateUpdate()
    {
        // Verifica si el jugador est� vivo antes de intentar seguirlo
        if (isPlayerAlive && target != null)
        {
            // Calcula la posici�n a la que la c�mara debe moverse
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            // Mueve suavemente la c�mara hacia la posici�n del jugador
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    // M�todo para detener el seguimiento del jugador
    public void StopFollowingPlayer()
    {
        isPlayerAlive = false;
    }
}
