using UnityEngine;
using UnityEngine.UI;

public class ControlDeJuego : MonoBehaviour
{
    public Text textoContador; // Asocia el objeto Text desde el Inspector de Unity

    void Start()
    {
        Button botonReinicio = GetComponent<Button>();
        botonReinicio.onClick.AddListener(ReiniciarJuego);
    }

    void ReiniciarJuego()
    {
        // Modifica el texto del objeto Text directamente para despausar el juego
        textoContador.text = "Juego Despausado";

        // Tambi�n puedes agregar aqu� cualquier otra l�gica que necesites al reiniciar el juego.
    }
}
