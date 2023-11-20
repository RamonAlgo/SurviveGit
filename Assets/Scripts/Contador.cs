using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public Text textoTiempo;
    private float tiempoInicio;
    private float tiempoPausaInicio;
    private float tiempoPausadoTotal = 0f;
    private bool juegoPausado = false;

    void Start()
    {
        // Registramos el tiempo de inicio cuando el juego comienza
        tiempoInicio = Time.realtimeSinceStartup;
    }

    void Update()
    {/*
        if (!juegoPausado)
        {
            float tiempoActual = Time.realtimeSinceStartup - tiempoInicio - tiempoPausadoTotal;
            textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoActual).ToString() + "s";

            if (tiempoActual >= 5f)
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        if (!juegoPausado)
        {
            Time.timeScale = 0f;
            juegoPausado = true;
            tiempoPausaInicio = Time.realtimeSinceStartup; // Registrar el inicio de la pausa
            MostrarTextoEnPantalla("Juego Pausado");
        }*/
    }

    public void DespausarJuego()
    {
        if (juegoPausado)
        {
            Debug.Log("Juego despausado");
            Time.timeScale = 1f;
            juegoPausado = false;
            tiempoPausadoTotal += Time.realtimeSinceStartup - tiempoPausaInicio; // Añadir al tiempo pausado total
        }
    }

    public void MostrarTextoEnPantalla(string mensaje)
    {
        // Implementación de la visualización del mensaje
    }
    }