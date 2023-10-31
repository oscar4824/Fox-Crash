using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float normalSpeed = 5f; // Velocidad normal del jugador
    public float sprintSpeed = 10f; // Velocidad cuando el jugador hace doble toque en la tecla de avanzar
    private bool isSprinting = false; // Variable para rastrear si el jugador está corriendo

    private float doubleTapTime = 0.3f; // Tiempo permitido entre dos toques para considerarlo como doble toque
    private float lastTapTime = 0f; // Tiempo del último toque

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcula la dirección del movimiento en 8 direcciones
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;
        moveDirection.Normalize();

        // Comprueba si el jugador está corriendo (doble toque en la tecla de avanzar)
        if (Input.GetKeyDown(KeyCode.W))
        {
            float timeSinceLastTap = Time.time - lastTapTime;
            if (timeSinceLastTap <= doubleTapTime)
            {
                isSprinting = true;
            }
            else
            {
                isSprinting = false;
            }
            lastTapTime = Time.time;
        }

        // Aplica la velocidad al movimiento
        float currentSpeed = isSprinting ? sprintSpeed : normalSpeed;
        moveDirection *= currentSpeed;

        controller.SimpleMove(moveDirection); // Utiliza SimpleMove para manejar la física del CharacterController
    }
}