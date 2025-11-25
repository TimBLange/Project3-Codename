using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float sensitivity = 10f;
    
    private CharacterController controller;
    private Vector3 moveInput;
    private Vector3 lookInput;
    private Vector3 velocity;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"moveInput: {moveInput}");
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        Debug.Log($"lookInput: {lookInput}");
    }
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
    }
}
