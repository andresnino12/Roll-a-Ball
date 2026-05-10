using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private Vector2 moveInput;  // guarda el input

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Este método se llama AUTOMÁTICAMENTE cuando hay input
    // Unity lo conecta solo si el método se llama OnMove
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.AddForce(movement * speed);
    }
}