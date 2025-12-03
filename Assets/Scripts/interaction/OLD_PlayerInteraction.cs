using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera playerCamera;
    public TextMeshProUGUI uiText;

    private ObjectInteract currentObj;
    private bool textVisible = false;

    void Update()
    {
        // E → Interactionn 
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (textVisible && currentObj != null && currentObj.hasSequence)
            {
                uiText.text = currentObj.GetNextSequenceText();
                return;
            }

            ToggleInteract();
        }

        // Q  E for Yes no choices
        if (currentObj != null && currentObj.hasChoices)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                uiText.text = currentObj.yesText;
                EndInteraction();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                uiText.text = currentObj.noText;
                EndInteraction();
            }
        }
    }

    void ToggleInteract()
    {
        if (textVisible)
        {
            uiText.text = "";
            textVisible = false;
            currentObj = null;
        }
        else
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            ObjectInteract obj = hit.collider.GetComponent<ObjectInteract>();

            if (obj != null)
            {
                currentObj = obj;

                // Reset multistep sequences
                obj.ResetSequence();

                // Show first prompt
                uiText.text = obj.GetText();
                textVisible = true;

                // If choices → append instructions
                if (obj.hasChoices)
                {
                    uiText.text += "\n(Q = Yes / E = No)";
                }
            }
        }
    }

    void EndInteraction()
    {
        textVisible = true;   // stays visible until next E
        currentObj = null;
    }
}
