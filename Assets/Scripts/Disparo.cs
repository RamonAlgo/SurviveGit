using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public float velocidadBala = 10f;
    private PlayerController playerController;
    [SerializeField] private Pausado_Reanuadado pausado;

    private void Start()
    {
        // Encuentra el componente PlayerController en el jugador
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))// && !pausado.keysEnabled
        {
            DispararBala();
        }
    }

    void DispararBala()
    {
        GameObject nuevaBala = Instantiate(balaPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = nuevaBala.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Dispara en la dirección del Spawner de Balas o en la dirección del jugador
            if (playerController != null)
            {
                if (playerController.MirandoDerecha())
                {
                    rb.velocity = transform.right * velocidadBala; // Dispara hacia la derecha
                }
                else
                {
                    rb.velocity = -transform.right * velocidadBala; // Dispara hacia la izquierda
                }
            }
            else
            {
                rb.velocity = transform.right * velocidadBala; // Dispara hacia la derecha por defecto
            }
        }
    }
}
