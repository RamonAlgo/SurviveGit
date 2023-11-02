using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    private float maxX;  // Límite máximo en el eje X
    private float minX; // Límite mínimo en el eje X
    private float maxY;
    private float minY;

    private Transform playerTransform; // Referencia al transform del jugador
    private bool mirandoDerecha = true; // Variable para controlar la dirección del jugador

    // Start is called before the first frame update
    void Start()
    {
        velocidadHorizontal = 8f;
        velocidadVertical = 8f;

        // Calcula los límites basados en el tamaño de la pantalla
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = screenAspect * cameraHeight;

        // Calcula el tamaño del jugador
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        float jugadorWidth = boxCollider2D.bounds.size.x / 2f;
        float jugadorHeight = boxCollider2D.bounds.size.y / 2f;

        minX = -cameraWidth + jugadorWidth;
        maxX = cameraWidth - jugadorWidth;
        minY = -cameraHeight + jugadorHeight;
        maxY = cameraHeight - jugadorHeight;

        // Obtiene la referencia al transform del jugador
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");  // Obtén la entrada vertical

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, direccionVertical).normalized; // Utiliza ambas direcciones

        Vector2 nuevaPosicion = playerTransform.position;

        nuevaPosicion += direccionIndicada * new Vector2(velocidadHorizontal, velocidadVertical) * Time.deltaTime;

        // Aplica las restricciones en ambos ejes (X e Y)
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, minY, maxY);

        // Actualiza la posición del jugador
        playerTransform.position = nuevaPosicion;

        // Voltea el jugador según la dirección
        if (direccionHorizontal > 0 && !mirandoDerecha)
        {
            // Si se está moviendo a la derecha y no mira a la derecha, voltea el jugador
            mirandoDerecha = true;
            playerTransform.localScale = new Vector3(Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
        }
        else if (direccionHorizontal < 0 && mirandoDerecha)
        {
            // Si se está moviendo a la izquierda y mira a la derecha, voltea el jugador
            mirandoDerecha = false;
            playerTransform.localScale = new Vector3(-Mathf.Abs(playerTransform.localScale.x), playerTransform.localScale.y, playerTransform.localScale.z);
        }
    }

    // Agrega este método para detectar colisiones

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
