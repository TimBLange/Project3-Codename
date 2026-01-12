using NUnit.Framework.Constraints;
using UnityEngine;


public class ToggleTooltip : MonoBehaviour
{
    public GameObject TooltipText;
    private bool TooltipShown;
    
    void Awake()
    {
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

    void HideToolTip()
    {
        TooltipText.SetActive(false);
        TooltipShown = false;
    }

    void ShowTooltip()
    {
        TooltipText.SetActive(true);
        TooltipShown = true;
    }

}
