using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Inventario : MonoBehaviour
{    
    public bool pez=true;
    public bool estambre=true;
    public bool raton=true;
    public bool calcetin=true;
    public TimeManager timeManager;
    private AudioSource audioSource; 
    public AudioClip miauClip;
        
    private bool prevPez;
    private bool prevEstambre;
    private bool prevRaton;
    private bool prevCalcetin;    
    void Start(){
        timeManager = GameObject.Find("Time").GetComponent<TimeManager>();
        audioSource = GetComponent<AudioSource>(); 
        prevPez = pez;
        prevEstambre = estambre;
        prevRaton = raton;
        prevCalcetin = calcetin;

    }
    void Update(){
        if (!pez && !estambre && !raton && !calcetin){
            timeManager.EndGame();
            SceneManager.LoadScene("End");
        }
        //if (!pez || !estambre || !raton || !calcetin){
        //    audioSource.PlayOneShot(miauClip);
        //}
        if ((prevPez && !pez) || (prevEstambre && !estambre) || (prevRaton && !raton) || (prevCalcetin && !calcetin))
        {
            audioSource.PlayOneShot(miauClip);
        }

        prevPez = pez;
        prevEstambre = estambre;
        prevRaton = raton;
        prevCalcetin = calcetin;

    }
}
