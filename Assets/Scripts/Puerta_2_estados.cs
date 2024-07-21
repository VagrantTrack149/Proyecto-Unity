using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta_2_estados : MonoBehaviour
{
    public Vector3 posicionCerrada = new Vector3(-9.8f, -1f, 0f);
    public Vector3 posicionAbierta = new Vector3(-14f, -1f, 0f);
    public GameObject objetoPuerta;
    public string etiquetaJugador = "Player";

    public bool playerInZone=false;

    private bool estaAbierta = false;

    private void Start()
    {
        if (objetoPuerta == null)
        {
            Debug.LogError("¡No hay ningún objeto puerta asignado al script Puerta_2_estados!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(etiquetaJugador))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(etiquetaJugador))
        {
            playerInZone = false;
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            estaAbierta = !estaAbierta;
            RotarOMoverObjeto();
        }
    }

    private void RotarOMoverObjeto()
    {
        if (estaAbierta)
        {
            objetoPuerta.transform.position = posicionAbierta;
        }
        else
        {
            objetoPuerta.transform.position = posicionCerrada;
        }
    }
}

