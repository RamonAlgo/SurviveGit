using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBuffs : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnInterval = 15.0f;

    private float minX = -82.73f;  // Límite izquierdo
    private float maxX = 68.52f;   // Límite derecho
    private float minY = -66.23f;  // Límite inferior
    private float maxY = 62.27f;   // Límite superior

    private void Start()
    {
        InvokeRepeating("SpawnBuff", 0f, spawnInterval);
    }

    private void SpawnBuff()
    {
        Debug.Log("Hola");
        // Genera una posición aleatoria dentro de los límites establecidos
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0); // Asegúrate de ajustar la coordenada Z si es necesario

        // Instancia el prefab del Buff en la posición calculada
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
