using UnityEngine;
using UnityEngine.InputSystem;
using JetBrains.Annotations;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isGround;
    [SerializeField] private float jumpForce;
    float movementx;
    float movementy;
    [SerializeField] private float speed = 5;
     public Rigidbody rb;
    private Camera PlayerCamera;
    private bool isJumping;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerCamera = Camera.main; 
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGround=true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGround=false;
        }
    }
    #region entradasTeclado
    void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();
        movementx = movement.x;
        movementy = movement.y;
    }
    #endregion

    void OnJump()
    {
        isJumping=true;
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = new Vector3();
        cameraForward = PlayerCamera.transform.forward;

        Vector3 cameraRight = new Vector3();
        cameraRight = PlayerCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y =0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movementDirection = (cameraForward * movementy)+(cameraRight * movementx);
        rb.AddForce(movementDirection * speed);
        if ( isJumping == true && isGround)
        {  
             rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
             isJumping=false;
        }    
            
    }
}