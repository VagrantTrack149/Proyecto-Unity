using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public Canvas canvas;
    public Canvas canvas1;
    public void QuitarCanva(){
        canvas.gameObject.SetActive(false);
        canvas1.gameObject.SetActive(true);
    }
    public void Escena1(){
        
       if (SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(1); 
        else
            SceneManager.LoadSceneAsync(1);
    }
    public void salir(){
        Application.Quit();
    }

    private void ReactivarMouse()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    private void Start()
    {
        ReactivarMouse();
    }

}
