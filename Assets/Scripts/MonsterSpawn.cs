using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnInterval = 1.0f;

    private float screenWidth;
    private float screenHeight;

    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        InvokeRepeating("SpawnMonster", 0f, spawnInterval);
    }

    private void SpawnMonster()
    {
        // Elige un borde aleatorio de la pantalla
        int edge = Random.Range(0, 4); // 0: izquierda, 1: derecha, 2: arriba, 3: abajo

        Vector3 spawnPosition = Vector3.zero;

        switch (edge)
        {
            case 0: // Izquierda
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, screenHeight), 10));
                break;
            case 1: // Derecha
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, Random.Range(0, screenHeight), 10));
                break;
            case 2: // Arriba
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, screenWidth), screenHeight, 10));
                break;
            case 3: // Abajo
                spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, screenWidth), 0, 10));
                break;
        }

        // Instancia el prefab del monstruo en la posición calculada
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
