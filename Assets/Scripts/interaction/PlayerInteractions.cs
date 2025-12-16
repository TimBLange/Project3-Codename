using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInteractions : MonoBehaviour
{
    public InputActionAsset interactActions;
    private InputActionMap _actionMap;
    
    public float interactDistance = 3f;
    public Camera playerCamera;
    private ObjectInteract currentObj;

    
    void OnEnable()
    {
        interactActions.Enable();
    }

    void OnDisable()
    {
        interactActions.Disable();
    }

    void Awake()
    {
        _actionMap = interactActions.FindActionMap("Player", true);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
            ShootRay();
    }
    
    void ShootRay()
    {
        if (playerCamera == null)
        {
            Debug.LogWarning("Player camera not set");
            return;
        }
        
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            ObjectInteract obj = hit.collider.GetComponent<ObjectInteract>();

            if (obj != null && obj.hasChoices)
            {
                if (Dialogue.instance != null)
                {
                    Dialogue.instance.dialogue(obj);    
                }
                else
                {
                    Debug.LogError("Dialgue object is null");
                }
            }
            else
            {
                Debug.Log("You missed...");
            }

            if (obj != null && !obj.hasChoices)
            {
                ObjectInteract.instance.BasicInteraction();
            }
        }
    }
}
