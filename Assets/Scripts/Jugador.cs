using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;

    // Establece los límites como variables públicas para que puedas ajustarlos en el Inspector de Unity
    public float maxX;  // Límite máximo en el eje X
    public float minX; // Límite mínimo en el eje X
    public float maxY;
    public float minY;

    private Transform playerTransform; // Referencia al transform del jugador
    private bool mirandoDerecha = true; // Variable para controlar la dirección del jugador

    void Start()
    {
        velocidadHorizontal = 8f;
        velocidadVertical = 8f;

        // Establece los límites basados en las coordenadas proporcionadas
        minX = -88.03f;  // Límite izquierdo
        maxX = 88.11f;   // Límite derecho
        minY = -48.43f;  // Límite inferior
        maxY = 48.90f;   // Límite superior

        // Obtiene la referencia al transform del jugador
        playerTransform = transform;
    }

    void Update()
    {
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, direccionVertical).normalized;

        Vector2 nuevaPosicion = playerTransform.position;

        nuevaPosicion += direccionIndicada * new Vector2(velocidadHorizontal, velocidadVertical) * Time.deltaTime;

        // Aplica las restricciones en ambos ejes (X e Y) con los límites personalizados
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, minY, maxY);

        // Actualiza la posición del jugador
        playerTransform.position = nuevaPosicion;

        // Voltea el jugador según la dirección
        if (direccionHorizontal > 0 && !mirandoDerecha)
        {
            mirandoDerecha = true;
            playerTransform.localScale = new Vector3(Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
        }
        else if (direccionHorizontal < 0 && mirandoDerecha)
        {
            mirandoDerecha = false;
            playerTransform.localScale = new Vector3(-Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Monster")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }

    public bool MirandoDerecha()
    {
        return mirandoDerecha;
    }
}
