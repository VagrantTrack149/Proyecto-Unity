using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raton : MonoBehaviour
{
    public Inventario inventario;
    public GameObject ratonImagen;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        ratonImagen=GameObject.Find("Raton");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player")
        {
            inventario.raton=false;
            ratonImagen.SetActive(false);
            Destroy(gameObject);
        }
    }
}