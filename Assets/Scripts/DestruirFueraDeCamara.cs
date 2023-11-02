using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFueraDeCamara : MonoBehaviour
{
    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Verifica si la bala est� fuera de la c�mara (fuera de la vista)
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            // Destruye la bala si est� fuera de la c�mara
            Destroy(gameObject);
        }
    }
}
