using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text TextPuntos;//Texto donde se muestran los puntos totales
    public Text TextTiempo;//Texto donde se muestra el tiempo total de partida

    // Start is called before the first frame update
    void Start()
    {
        TextPuntos.text = PlayerPrefs.GetString("Puntos_totales");
        TextTiempo.text = PlayerPrefs.GetString("Tiempo_Total");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
