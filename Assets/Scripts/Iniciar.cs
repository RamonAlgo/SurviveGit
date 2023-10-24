using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public void CambiarAEscenaGame()
    {
        SceneManager.LoadScene("Game"); // cambiem a la escena Game
    }
    public void CambiarAEscenaRanking()
    {
        SceneManager.LoadScene("Ranking"); // cambiem a la escena Ranking
    }

    public void CambiarAEscenaInfo()
    {
        SceneManager.LoadScene("Info"); // cambiem a la escena Info
    }
}

