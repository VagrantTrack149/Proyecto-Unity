using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estambre : MonoBehaviour
{
    public Inventario inventario;
    public GameObject estambreImagen;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        estambreImagen=GameObject.Find("Estambre");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player")
        {
            inventario.estambre=false;
            estambreImagen.SetActive(false);
            Destroy(gameObject);
        }
    }
}