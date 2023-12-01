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
        minX = -82.73f;  // Límite izquierdo
        maxX = 68.52f;   // Límite derecho
        minY = -66.23f;  // Límite inferior
        maxY = 62.27f;   // Límite superior

        // Obtiene la referencia al transform del jugador
        playerTransform = transform;
    }
    // Método para incrementar la velocidad
    private void IncrementarVelocidad(float incremento)
    {
        velocidadHorizontal += incremento;
        velocidadVertical += incremento;
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
    // Método para incrementar la velocidad

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Monster")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
        else if (objecteTocat.tag == "Buf_speed")
        {
            IncrementarVelocidad(3f); // Aumentar la velocidad en 3
            Destroy(objecteTocat.gameObject); // Destruye el objeto Buf_speed
        }
    }

    public bool MirandoDerecha()
    {
        return mirandoDerecha;
    }
}
