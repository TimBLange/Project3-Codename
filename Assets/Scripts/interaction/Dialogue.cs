using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;
    
    public InputActionAsset interactActions;
    private InputActionMap _actionMapPlayer;
    private InputActionMap _actionMapDialogue;
    
    private ObjectInteract currentObj;
    
    public TextMeshProUGUI uiText;
    
    private bool textVisible = false;
    public bool talking = false;
    
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
        if (instance != null && instance != this)
        {
            
            return;
        }
        
        instance = this;
        
        _actionMapPlayer = interactActions.FindActionMap("Player", true);
        _actionMapDialogue = interactActions.FindActionMap("Dialogue", true);
    }
    
    public void dialogue(object obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("Dialogue object is null");
            
            if (currentObj == null)
                        return;
        }
        
        currentObj = (ObjectInteract)obj;
        currentObj.ResetSequence();
        
        _actionMapDialogue.Enable();
        _actionMapPlayer.Disable();
        

        uiText.text = currentObj.GetText();
        textVisible = true;
        talking = true;
        
        if (currentObj.hasChoices)
        {
            uiText.text += "\n(Q = Yes | E = No)";
        }
    }
    
    public void OnExit(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        
        EndDialogue();
    }

    public void OnYes(InputAction.CallbackContext context)
    {
        if (!context.performed || !talking || currentObj == null || !currentObj.hasChoices)
        {
            
            return;
        }

        Debug.Log("Yes Performed");
        uiText.text = currentObj.yesText;
        talking = false;
    }
    public void OnNo(InputAction.CallbackContext context)
    {
        if (!context.performed || !talking || currentObj == null || !currentObj.hasChoices)
        {
            return;
        }

        Debug.Log("No Performed");
        uiText.text = currentObj.noText;
        talking = false;
    }
    
    public void EndDialogue()
    {
        talking = false;
        textVisible = false;
        currentObj = null;

        if (uiText != null)
        {
            uiText.text = "";
        }

        _actionMapDialogue.Disable();
        _actionMapPlayer.Enable();
        
        
        Debug.Log("Dialogue End");
    }
}
