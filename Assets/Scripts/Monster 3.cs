using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float changeDirectionInterval = 2.0f; // Intervalo para cambiar de direcci�n
    private Transform player; // El transform del jugador
    private Vector3 randomDirection; // Direcci�n aleatoria
    private float nextDirectionChangeTime;
    private void ActivateMonster()
    {
        // Activa el monstruo y establece la direcci�n inicial
        gameObject.SetActive(true);
        SetRandomDirection();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador por el tag "Player"
        SetRandomDirection();
        gameObject.SetActive(false);
        Invoke("ActivateMonster", 20.0f);
    }

    private void Update()
    {
        if (player != null)
        {
            if (Time.time >= nextDirectionChangeTime)
            {
                SetRandomDirection();
                nextDirectionChangeTime = Time.time + changeDirectionInterval;
            }

            // Calcula la direcci�n hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Combina la direcci�n hacia el jugador con la direcci�n aleatoria
            Vector3 movement = direction + randomDirection;

            // Normaliza la direcci�n
            movement.Normalize();

            // Mueve el monstruo hacia el jugador con la direcci�n combinada
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    // Genera una direcci�n aleatoria
    private void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }
}
