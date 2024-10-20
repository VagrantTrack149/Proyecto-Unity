using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class Pescado : MonoBehaviour
{
    public Inventario inventario;
    public GameObject pezImagen;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        pezImagen = GameObject.Find("Pez");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player")
        {
            inventario.pez=false;
            pezImagen.SetActive(false);
            Destroy(gameObject);
        }
    }
}