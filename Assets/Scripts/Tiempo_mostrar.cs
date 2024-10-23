using UnityEngine;
using UnityEngine.UI;

public class Tiempo_mostrar : MonoBehaviour
{
    public Text timeTexto;
    public Text timeReal;  
    private float startTime;

    void Start()
    {
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime");
        DisplayTime(elapsedTime, timeTexto);
        startTime = Time.time;

    }

    void DisplayTime(float timeToDisplay, Text textField)
    {
        if (textField == null) return;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        textField.text = $"{minutes:D2}:{seconds:D2}";
    }
    void Update(){
        float realTime = Time.time - startTime;
        if (timeReal != null)
        {
            DisplayTime(realTime, timeReal);
        }
    }
}
