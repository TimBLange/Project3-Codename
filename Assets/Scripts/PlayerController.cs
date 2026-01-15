using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -30f; //-9.81f
    Vector3 verticalVelocity = Vector3.zero;

    [SerializeField] private Transform cam;
    [SerializeField] private float sensitivity = 5;


    private CharacterController controller;
    private Vector3 moveInput;
    private Vector3 lookInput;
    private Vector3 velocity;
    private float pitch;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();   
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log($"Are you moving Son? {moveInput}");
    }

    public void onLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        //Debug.Log($"Are you looking Son? {lookInput}");
    }
    
    void Update()
    {
        
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);
        controller.Move(move * speed * Time.deltaTime);
        
        Vector2 look = lookInput * sensitivity * Time.deltaTime;
        
        transform.Rotate(Vector3.up * look.x);
        
        pitch -= look.y;
        pitch = Mathf.Clamp(pitch, -90, 90);
        cam.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Period))
        {
            speed = 20;
        }

        if (Input.GetKeyUp(KeyCode.Period))
        {
            speed = 5;
        }
        
    }
}
