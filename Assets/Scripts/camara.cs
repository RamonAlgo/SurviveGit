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
            // Obtiene la posici�n actual de la c�mara
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Interpola suavemente entre la posici�n actual y la posici�n deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posici�n de la c�mara
            transform.position = smoothedPosition;
        }
    }
}
