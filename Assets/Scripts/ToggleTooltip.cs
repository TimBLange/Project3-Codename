using NUnit.Framework.Constraints;
using UnityEngine;


public class ToggleTooltip : MonoBehaviour
{
    public GameObject TooltipText;
    public bool TooltipShown;
    
    public static ToggleTooltip instance;
    
    void Awake()
    {
        instance = this;
        TooltipText.SetActive(false);
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

    public void HideToolTip()
    {
        TooltipText.SetActive(false);
        TooltipShown = false;
    }

    public void ShowTooltip()
    {
        TooltipText.SetActive(true);
        TooltipShown = true;
    }

}
