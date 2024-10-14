using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public void Escena1()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void salir(){
        Application.Quit();
    }
}
