using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Playermovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1f;
    public float sensitivity = 2f;

    public Transform PlayerCam;
    private float cameraVerticalRotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        transform.Rotate(Vector3.up * mouseX);

        cameraVerticalRotation -= mouseY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        PlayerCam.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);
    }
    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += transform.forward;
        if (Input.GetKey(KeyCode.S))
            moveDirection -= transform.forward;
        if (Input.GetKey(KeyCode.A))
            moveDirection -= transform.right;
        if (Input.GetKey(KeyCode.D))
            moveDirection += transform.right;

        moveDirection.y = 0;
        moveDirection.Normalize();

        rb.AddForce(moveDirection * speed, ForceMode.Impulse);
    }
    
}
