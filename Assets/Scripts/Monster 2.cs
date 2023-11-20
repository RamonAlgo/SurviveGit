using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float frequency = 1.0f; // Controla la frecuencia del movimiento S
    private Transform player; // El transform del jugador
    private Vector3 initialPosition; // La posición inicial del monstruo
    private float startTime;

    void ActivateMonster()
    {
        // Activa el monstruo
        gameObject.SetActive(true);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador por el tag "Player"
        initialPosition = transform.position;
        startTime = Time.time;

        gameObject.SetActive(false);

        Invoke("ActivateMonster", 10.0f);

    }

    private void Update()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Calcula el desplazamiento en el eje X e Y en forma de "S"
            float offsetX = Mathf.Sin((Time.time - startTime) * frequency);
            float offsetY = Mathf.Sin((Time.time - startTime) * frequency * 2); // Ajusta la frecuencia para la forma de "S"

            // Aplica la dirección hacia el jugador
            Vector3 movement = direction + new Vector3(offsetX, offsetY, 0f);

            // Normaliza la dirección
            movement.Normalize();

            // Mueve el monstruo hacia el jugador en el patrón de movimiento "S"
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }
}
