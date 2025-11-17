using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera playerCamera;
    public TextMeshProUGUI uiText;

    private bool textVisible = false;            // merkt  ob text an ist
    private string currentText = "";             // speichert den text des Objekts

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textVisible)
            {
                
                uiText.text = "";
                textVisible = false;
            }
            else
            {
                
                TryInteract();
            }
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
                currentText = obj.GetText();  // Text holen
                uiText.text = currentText;    // anzeigen
                textVisible = true;           // merken dass Text aktiv ist
            }
        }
    }
}
