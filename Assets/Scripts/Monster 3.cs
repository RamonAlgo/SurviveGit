using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float changeDirectionInterval = 2.0f; // Intervalo para cambiar de dirección
    private Transform player; // El transform del jugador
    private Vector3 randomDirection; // Dirección aleatoria
    private float nextDirectionChangeTime;
    private void ActivateMonster()
    {
        // Activa el monstruo y establece la dirección inicial
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

            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Combina la dirección hacia el jugador con la dirección aleatoria
            Vector3 movement = direction + randomDirection;

            // Normaliza la dirección
            movement.Normalize();

            // Mueve el monstruo hacia el jugador con la dirección combinada
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    // Genera una dirección aleatoria
    private void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }
}
