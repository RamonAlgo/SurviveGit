using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    private float maxX;  // L�mite m�ximo en el eje X
    private float minX; // L�mite m�nimo en el eje X
    private float maxY;
    private float minY;
    // Start is called before the first frame update
    void Start()
    {
        velocidadHorizontal = 6f;
        velocidadVertical = 6f;

        // Calcula los l�mites basados en el tama�o de la pantalla
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = screenAspect * cameraHeight;

        // Calcula el tama�o del jugador
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        float jugadorWidth = boxCollider2D.bounds.size.x / 2f;
        float jugadorHeight = boxCollider2D.bounds.size.y / 2f;

        minX = -cameraWidth + jugadorWidth;
        maxX = cameraWidth - jugadorWidth;
        minY = -cameraHeight + jugadorHeight;
        maxY = cameraHeight - jugadorHeight;
    }

    // Update is called once per frame
    void Update()
    {
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");  // Obt�n la entrada vertical

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, direccionVertical).normalized; // Utiliza ambas direcciones

        Vector2 nuevaPosicion = transform.position;

        nuevaPosicion += direccionIndicada * new Vector2(velocidadHorizontal, velocidadVertical) * Time.deltaTime;

        // Aplica las restricciones en ambos ejes (X e Y)
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, minY, maxY);

        transform.position = nuevaPosicion;

    }

     // Agrega este m�todo para detectar colisiones

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Monster")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
