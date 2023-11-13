using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad suave de seguimiento

    void LateUpdate()
    {
        if (target != null)
        {
            // Obtiene la posición actual de la cámara
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Interpola suavemente entre la posición actual y la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
