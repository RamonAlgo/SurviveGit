using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float frequency = 1.0f; // Controla la frecuencia del movimiento sinusoidal
    private Transform player; // El transform del jugador
    private Vector3 initialPosition; // La posici�n inicial del monstruo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador por el tag "Player"
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (player != null)
        {
            // Calcula la direcci�n hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Calcula el movimiento sinusoidal en X y Y
            float sinX = Mathf.Sin(Time.time * frequency);
            float cosY = Mathf.Cos(Time.time * frequency);

            // Calcula el desplazamiento en el eje X e Y
            float offsetX = sinX * 2.0f; // Controla el tama�o del patr�n
            float offsetY = cosY * 1.0f; // Controla el tama�o del patr�n

            // Aplica la direcci�n hacia el jugador
            Vector3 movement = direction + new Vector3(offsetX, offsetY, 0f);

            // Normaliza la direcci�n
            movement.Normalize();

            // Mueve el monstruo hacia el jugador en el patr�n de movimiento sinusoidal
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}
