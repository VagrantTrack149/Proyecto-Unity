using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    public Vector3 offset; // Offset de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento
    public float rotationSpeed = 100.0f; // Velocidad de rotación con el ratón

    private float mouseX;
    private float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
        offset = transform.position - target.position; // Calcular el offset inicial
    }

    void LateUpdate()
    {
        // Obtener la entrada del ratón
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Limitar el movimiento vertical del ratón
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        // Rotar la cámara alrededor del jugador
        Quaternion camRotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.position = target.position + camRotation * offset;

        // Mirar hacia el jugador
        transform.LookAt(target);
    }
}
