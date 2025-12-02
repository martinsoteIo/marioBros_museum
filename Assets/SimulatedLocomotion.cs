using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimulatedLocomotion : MonoBehaviour
{
    public Transform forwardSource;   // arrastra aquí la Main Camera
    public float moveSpeed = 1f;
    public float gravity = -9.81f;    // fuerza de gravedad
    public float groundedOffset = 0.05f; // margen para detectar suelo

    private CharacterController cc;
    private float verticalVelocity = 0f;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --- Movimiento horizontal (WASD) ---
        float x = 0f, y = 0f;
        if (Input.GetKey(KeyCode.W)) y += 1f;
        if (Input.GetKey(KeyCode.S)) y -= 1f;
        if (Input.GetKey(KeyCode.D)) x += 1f;
        if (Input.GetKey(KeyCode.A)) x -= 1f;

        Vector3 forward = Vector3.ProjectOnPlane(forwardSource.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(forwardSource.right, Vector3.up).normalized;
        Vector3 move = (forward * y + right * x).normalized * moveSpeed;

        // --- Detección de suelo ---
        bool isGrounded = cc.isGrounded || Physics.Raycast(transform.position, Vector3.down, cc.height / 2f + groundedOffset);

        // --- Gravedad manual ---
        if (isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f; // mantener pegado al suelo
        else
            verticalVelocity += gravity * Time.deltaTime; // acumular caída

        // --- Aplicar movimiento total ---
        Vector3 totalMove = move + Vector3.up * verticalVelocity;
        cc.Move(totalMove * Time.deltaTime);
    }
}
