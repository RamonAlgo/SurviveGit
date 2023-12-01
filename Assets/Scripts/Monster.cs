using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static float globalMoveSpeed = 5.0f;

    private Transform player; // El transform del jugador

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador por el tag "Player"
    }

    private void Update()
    {
        if (player != null)
        {
            // Usa globalMoveSpeed para el movimiento
            Vector3 direction = (player.position - transform.position).normalized;
            // Movimiento hacia el jugador
            transform.Translate(direction * globalMoveSpeed * Time.deltaTime);
        } 
    }
    public static void IncreaseGlobalSpeed()
    {
        globalMoveSpeed += 2; // Incrementa la velocidad global
    }
    public static void DecreaseGlobalSpeed()
    {
        globalMoveSpeed -= 1; // Incrementa la velocidad global
    }
}
