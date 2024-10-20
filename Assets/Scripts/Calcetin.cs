using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcetin : MonoBehaviour
{
    public Inventario inventario;
    public GameObject calcetinImagen;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        calcetinImagen=GameObject.Find("Calcetin");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player")
        {
            inventario.calcetin=false;
            calcetinImagen.SetActive(false);
            Destroy(gameObject);
        }
    }
}