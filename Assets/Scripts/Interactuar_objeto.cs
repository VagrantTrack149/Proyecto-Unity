using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar_objeto : MonoBehaviour
{
    public Inventario inventario;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player")
        {
            inventario.pez=true;
            Destroy(gameObject);
        }
    }
}
