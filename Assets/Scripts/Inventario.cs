using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventario : MonoBehaviour
{    
    public bool pez=true;
    public bool estambre=true;
    public bool raton=true;
    public bool calcetin=true;
    public TimeManager timeManager;
    private AudioSource audioSource; 
    public AudioClip miauClip;
        
    void Start(){
        timeManager = GameObject.Find("Time").GetComponent<TimeManager>();
        audioSource = GetComponent<AudioSource>(); 
    }
    void Update(){
        if (!pez && !estambre && !raton && !calcetin){
            timeManager.EndGame();
        }
        if (pez || estambre || raton || calcetin)
        {
            ReproducirMiau();
        }
    }
    private void ReproducirMiau()
    {
        if (audioSource != null && miauClip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(miauClip);
        }
    }

}
