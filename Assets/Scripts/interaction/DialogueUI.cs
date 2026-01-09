using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI instance;

    [Header("UI References")]
    public GameObject dialogueRoot;   // z.B. DialogueUI
    public Image backgroundImage;     // Textbox Hintergrund
    public TMP_Text dialogueText;     // Interaction Text

    private void Awake()
    {
        Debug.Log("[DialogueUI] Awake() aufgerufen");

        // Singleton
        if (instance != null && instance != this)
        {
            Debug.LogWarning("[DialogueUI] Zweite Instanz gefunden → wird zerstört");
            Destroy(gameObject);
            return;
        }

        instance = this;
        Debug.Log("[DialogueUI] Instance gesetzt");

        Hide();
    }

    public void Show(string text)
    {
        Debug.Log("[DialogueUI] Show() aufgerufen mit Text: " + text);

        if (dialogueRoot == null)
        {
            Debug.LogError("[DialogueUI] dialogueRoot NICHT zugewiesen!");
            return;
        }

        if (backgroundImage == null)
        {
            Debug.LogError("[DialogueUI] backgroundImage NICHT zugewiesen!");
            return;
        }

        if (dialogueText == null)
        {
            Debug.LogError("[DialogueUI] dialogueText NICHT zugewiesen!");
            return;
        }

        dialogueRoot.SetActive(true);
        Debug.Log("[DialogueUI] dialogueRoot AKTIV");

        backgroundImage.gameObject.SetActive(true);
        Debug.Log("[DialogueUI] backgroundImage AKTIV");

        dialogueText.gameObject.SetActive(true);
        Debug.Log("[DialogueUI] dialogueText AKTIV");

        dialogueText.text = text;
        Debug.Log("[DialogueUI] Text gesetzt");
    }

    public void Hide()
    {
        Debug.Log("[DialogueUI] Hide() aufgerufen");

        if (dialogueText != null)
        {
            dialogueText.text = "";
            dialogueText.gameObject.SetActive(false);
            Debug.Log("[DialogueUI] dialogueText AUS");
        }
        else
        {
            Debug.LogWarning("[DialogueUI] dialogueText war null");
        }

        if (backgroundImage != null)
        {
            backgroundImage.gameObject.SetActive(false);
            Debug.Log("[DialogueUI] backgroundImage AUS");
        }
        else
        {
            Debug.LogWarning("[DialogueUI] backgroundImage war null");
        }

        if (dialogueRoot != null)
        {
            dialogueRoot.SetActive(false);
            Debug.Log("[DialogueUI] dialogueRoot AUS");
        }
        else
        {
            Debug.LogWarning("[DialogueUI] dialogueRoot war null");
        }
    }
}
