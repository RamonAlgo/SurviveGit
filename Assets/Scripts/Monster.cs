using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Transform player; // El transform del jugador

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador por el tag "Player"
    }

    private void Update()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Mueve el monstruo hacia el jugador
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
