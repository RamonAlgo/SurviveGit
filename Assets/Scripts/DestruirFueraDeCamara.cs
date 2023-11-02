using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirFueraDeCamara : MonoBehaviour
{
    private void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // Verifica si la bala está fuera de la cámara (fuera de la vista)
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            // Destruye la bala si está fuera de la cámara
            DestruirBala();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            // Destruye el objeto con etiqueta "Monster" que toca
            Destroy(other.gameObject);

            // Destruye la bala
            DestruirBala();
        }
    }

    private void DestruirBala()
    {
        // Destruye la bala actual
        Destroy(gameObject);
    }
}