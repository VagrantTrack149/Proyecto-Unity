using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        DontDestroyOnLoad(this.gameObject);
    }

    public void EndGame()
    {
        float elapsedTime = Time.time - startTime;
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        
        SceneManager.LoadScene("End");
    }
}
