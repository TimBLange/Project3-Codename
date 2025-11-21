using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    [Header("Basic Interaction Text")]
    public string interactionText = "";        // z.B. Prompt

    [Header("Optional: Yes/No Choices")]
    public bool hasChoices = false;
    public string yesText = "";
    public string noText = "";

    [Header("Optional: Multi-Step Sequence")]
    [TextArea] public string[] sequenceTexts;

    private int sequenceIndex = 0;
    public bool hasSequence => sequenceTexts != null && sequenceTexts.Length > 0;

    public string GetText()
    {
        if (!hasSequence) return interactionText;
        return sequenceTexts[sequenceIndex];
    }

    public string GetNextSequenceText()
    {
        if (!hasSequence) return "";
        sequenceIndex = Mathf.Min(sequenceIndex + 1, sequenceTexts.Length - 1);
        return sequenceTexts[sequenceIndex];
    }

    public void ResetSequence()
    {
        sequenceIndex = 0;
    }
}
