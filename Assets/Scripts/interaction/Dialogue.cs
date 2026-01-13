using System;
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
    public GameObject InteractionCanvas;
    
    private bool textVisible = false;
    public bool talking = false;


    private void Start()
    {
        instance = this;
    }

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
        
        InteractionCanvas.SetActive(false);
        
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
        
        InteractionCanvas.SetActive(true);
        
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
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

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
        
        InteractionCanvas.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        if (ToggleTooltip.instance.TooltipShown == true)
        {
            ToggleTooltip.instance.OnToggle();
        }
        
        //Debug.Log("Dialogue End");
    }
}
