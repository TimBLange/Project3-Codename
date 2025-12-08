using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;

    public InputActionAsset interactActions;
    private InputActionMap _actionMapPlayer;
    private InputActionMap _actionMapDialogue;

    private InputAction _nextAction;
    private InputAction _yesAction;
    private InputAction _noAction;
    private InputAction _exitAction;

    private ObjectInteract currentObj;

    public TextMeshProUGUI uiText;

    private bool talking = false;

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
        instance = this;

        _actionMapPlayer = interactActions.FindActionMap("Player", true);
        _actionMapDialogue = interactActions.FindActionMap("Dialogue", true);

        _nextAction = _actionMapDialogue.FindAction("Next", true);
        _yesAction = _actionMapDialogue.FindAction("Yes", true);
        _noAction = _actionMapDialogue.FindAction("No", true);
        _exitAction = _actionMapDialogue.FindAction("Exit", true);

        _nextAction.performed += OnNext;
        _yesAction.performed += OnYes;
        _noAction.performed += OnNo;
        _exitAction.performed += OnExit;
    }

    public void dialogue(object obj)
    {
        currentObj = (ObjectInteract)obj;
        currentObj.ResetSequence();

        talking = true;
        uiText.text = currentObj.GetText();

        if (currentObj.hasChoices)
            uiText.text += "\n\n(Confirm = Yes | Cancel = No)";

        _actionMapPlayer.Disable();
        _actionMapDialogue.Enable();
    }

    public void OnNext(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || !talking || currentObj == null)
            return;

        if (currentObj.hasChoices)
            return;

        if (currentObj.hasSequence && currentObj.GetNextSequenceText() != currentObj.GetText())
        {
            uiText.text = currentObj.GetText();
            return;
        }

        EndDialogue();
    }

    public void OnYes(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || currentObj == null || !currentObj.hasChoices)
            return;

        uiText.text = currentObj.yesText;

    }

    public void OnNo(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || currentObj == null || !currentObj.hasChoices)
            return;

        uiText.text = currentObj.noText;

    }



    public void OnExit(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || !talking)
            return;

        EndDialogue();
    }

    public void EndDialogue()
    {
        talking = false;
        currentObj = null;
        uiText.text = "";

        _actionMapDialogue.Disable();
        _actionMapPlayer.Enable();
    }
}
