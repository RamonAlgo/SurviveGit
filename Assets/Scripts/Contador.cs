using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text textoTiempo;
    private float tiempoTranscurrido = 0f;
    private bool juegoPausado = false;

    void Update()
    {
        if (!juegoPausado)
        {
            tiempoTranscurrido += Time.deltaTime;
            textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoTranscurrido).ToString() + "s";

            if (tiempoTranscurrido >= 5f)
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        Time.timeScale = 0f; // Pausa el tiempo en el juego
        juegoPausado = true;
        MostrarTextoEnPantalla("Juego Pausado");
    }

    public void DespausarJuego()
    {
        Debug.Log("Juego despausado");
        // Cambia el estado de pausa del juego
        juegoPausado = false;
        Time.timeScale = 1f;
    }
    public void MostrarTextoEnPantalla(string mensaje)
    {
        // Aquí puedes mostrar el texto en pantalla, por ejemplo, activando un objeto Text en la interfaz de usuario.
        // Supongamos que tienes un objeto Text llamado "textoPausa" en tu interfaz de usuario.
        //textoPausa.gameObject.SetActive(true);
        //textoPausa.text = mensaje;
    }

    void OnCLickTest() { 
           
    }
}
