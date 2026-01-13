using NUnit.Framework.Constraints;
using UnityEngine;


public class ToggleTooltip : MonoBehaviour
{
    public GameObject TooltipTextGO;
    private TMPro.TMP_Text TooltipTextbox;
    public bool TooltipShown;
    
    public static ToggleTooltip instance;
    
    private HelpText currentNPC;

    
    void Awake()
    {
        //Debug.Log(HelpText.instance.NPCTip);
        TooltipTextbox=TooltipTextGO.GetComponent<TMPro.TMP_Text>();
        instance = this;
        TooltipTextGO.SetActive(false);
        TooltipShown = false;
    }

    public void OnToggle()
    {
        if (TooltipShown == true)
        { 
            Debug.Log("ASDASDA");
            HideToolTip();
        }
        else
        {
            ShowTooltip();
        }
    }

    private void HideToolTip()
    {
        TooltipTextGO.SetActive(false);
        TooltipShown = false;
    }

    private void ShowTooltip()
    {
        
        TooltipTextGO.SetActive(true);
        TooltipShown = true;
    }

    public void GetTooltipText(string text)
    {
        Debug.Log("hellllp");
        TooltipTextbox.text = text;
        

    }
}
