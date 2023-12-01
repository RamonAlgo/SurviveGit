using System;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    //boton reanudar juego public Button resumeButton; // Botón para reanudar el juego
    public Text timeText; // Texto para mostrar el tiempo transcurrido
    public Text OperacionMates; // Texto para la operación 
    public Button resultadoButton1;
    public Text TextRes1;
    public Button resultadoButton2;
    public Text TextRes2;
    public Button resultadoButton3;
    public Text TextRes3;
    private float gameTime = 0f; // Tiempo transcurrido del juego
    private bool isPaused = false; // Estado de pausa del juego

    private int correctAnswer;
    void Start()
    {
        resultadoButton1.onClick.AddListener(() => AnswerButtonClicked(resultadoButton1));
        resultadoButton2.onClick.AddListener(() => AnswerButtonClicked(resultadoButton2));
        resultadoButton3.onClick.AddListener(() => AnswerButtonClicked(resultadoButton3));

        // Inicializar los botones y el texto de las operaciones como inactivos
        OperacionMates.gameObject.SetActive(false);
        resultadoButton1.gameObject.SetActive(false);
        resultadoButton2.gameObject.SetActive(false);
        resultadoButton3.gameObject.SetActive(false);
        TextRes1.gameObject.SetActive(false);
        TextRes2.gameObject.SetActive(false);
        TextRes3.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isPaused)
        {
            gameTime += Time.deltaTime; // Incrementar el tiempo del juego
            UpdateTimeText(); // Actualizar el texto de tiempo
            CheckForPause(); // Verificar si es necesario pausar
        }
    }
    void AnswerButtonClicked(Button button)
    {
        // Verificar la respuesta y luego reanudar el juego
        CheckAnswer(Int32.Parse(button.GetComponentInChildren<Text>().text));
        ResumeGame();
    }
    void UpdateTimeText()
    {
        // Formatear el tiempo a minutos y segundos
        int minutes = (int)gameTime / 60;
        int seconds = (int)gameTime % 60;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CheckForPause()
    {
        // Verificar si el tiempo del juego coincide con alguno de los intervalos especificados
        if ((int)gameTime % 5 == 0 && (int)gameTime != 0)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Detener el tiempo en el juego

        // Mostrar los elementos de la UI
        
        OperacionMates.gameObject.SetActive(true);
        resultadoButton1.gameObject.SetActive(true);
        resultadoButton2.gameObject.SetActive(true);
        resultadoButton3.gameObject.SetActive(true);
        TextRes1.gameObject.SetActive(true);
        TextRes2.gameObject.SetActive(true);
        TextRes3.gameObject.SetActive(true);
        

        GenerateMathQuestion(); // Generar una nueva pregunta matemática
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Reanudar el tiempo en el juego
        gameTime++; // Evitar que el juego se pause inmediatamente después de reanudar

        // Ocultar los elementos de la UI
        OperacionMates.gameObject.SetActive(false);
        resultadoButton1.gameObject.SetActive(false);
        resultadoButton2.gameObject.SetActive(false);
        resultadoButton3.gameObject.SetActive(false);
        TextRes1.gameObject.SetActive(false);
        TextRes2.gameObject.SetActive(false);
        TextRes3.gameObject.SetActive(false);
        
    }
    void GenerateMathQuestion()
    {
        int a = UnityEngine.Random.Range(1, 10);
        int b = UnityEngine.Random.Range(1, 10);
        int operation = UnityEngine.Random.Range(0, 4); // Genera un número entre 0 y 3

        switch (operation)
        {
            case 0: // Suma
                correctAnswer = a + b;
                OperacionMates.text = $"{a} + {b} = ?";
                break;
            case 1: // Resta
                correctAnswer = a - b;
                OperacionMates.text = $"{a} - {b} = ?";
                break;
            case 2: // Multiplicación
                correctAnswer = a * b;
                OperacionMates.text = $"{a} * {b} = ?";
                break;
            case 3: // División
                    // Asegúrate de que b no sea cero para evitar la división por cero
                b = (b == 0) ? 1 : b;
                correctAnswer = a / b;
                OperacionMates.text = $"{a} / {b} = ?";
                break;
        }

        SetAnswerButtons();
    }

    int GenerateWrongAnswer(int correctAnswer)
    {
        // Genera una respuesta incorrecta que no sea igual a la respuesta correcta
        int wrongAnswer;
        do
        {
            wrongAnswer = UnityEngine.Random.Range(1, 20);
        }
        while (wrongAnswer == correctAnswer);

        return wrongAnswer;
    }

    void CheckAnswer(int selectedAnswer)
    {
        if (selectedAnswer == correctAnswer)
        {
            Monster.DecreaseGlobalSpeed(); //Disminuye la velocidad global de los monstruos
            ResumeGame();
        }
        else
        {
            Monster.IncreaseGlobalSpeed(); // Incrementa la velocidad global de los monstruos
        }
    }

    void SetWrongAnswers(Button wrongButton1, Button wrongButton2)
    {
        Debug.Log("Entrando en SetWrongAnswers");

        int wrongAnswer1 = GenerateWrongAnswer(correctAnswer);
        int wrongAnswer2 = GenerateWrongAnswer(correctAnswer);

        Debug.Log($"Respuestas incorrectas iniciales: {wrongAnswer1}, {wrongAnswer2}");

        // Asegúrate de que las respuestas incorrectas no sean iguales entre sí o a la correcta
        while (wrongAnswer2 == wrongAnswer1 || wrongAnswer2 == correctAnswer)
        {
            wrongAnswer2 = GenerateWrongAnswer(correctAnswer);
            Debug.Log($"Generando nueva respuesta incorrecta: {wrongAnswer2}");
        }

        Debug.Log($"Asignando respuestas a botones: {wrongAnswer1} a {wrongButton1.name}, {wrongAnswer2} a {wrongButton2.name}");

        wrongButton1.GetComponentInChildren<Text>().text = wrongAnswer1.ToString();
        wrongButton2.GetComponentInChildren<Text>().text = wrongAnswer2.ToString();
    }

    void SetAnswerButtons()
    {
        int correctButtonIndex = UnityEngine.Random.Range(1, 4); // Número entre 1 y 3
        Debug.Log(resultadoButton1.GetComponentInChildren<Text>());
        switch (correctButtonIndex)
        {
            case 1:
                resultadoButton1.GetComponentInChildren<Text>().text = correctAnswer.ToString();
                SetWrongAnswers(resultadoButton2, resultadoButton3);
                break;
            case 2:
                resultadoButton2.GetComponentInChildren<Text>().text = correctAnswer.ToString();
                SetWrongAnswers(resultadoButton1, resultadoButton3);
                break;
            case 3:
                resultadoButton3.GetComponentInChildren<Text>().text = correctAnswer.ToString();
                SetWrongAnswers(resultadoButton1, resultadoButton2);
                break;
        }
    }


}
