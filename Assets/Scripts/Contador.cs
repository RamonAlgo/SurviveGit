using UnityEngine;
using UnityEngine.UI;

public class TiempoDePartida : MonoBehaviour
{
    public Text textoTiempo;
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        textoTiempo.text = "Tiempo: " + Mathf.Round(tiempoTranscurrido).ToString()+"s";
    }
}
