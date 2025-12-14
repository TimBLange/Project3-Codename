using System;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public static ObjectInteract instance;
    
    [Header("Basic Interaction Text")]
    public string interactionText = "";

    [Header("Optional: Yes/No Choices")]
    public bool hasChoices = false;
    public string yesText = "";
    public string noText = "";

    [Header("Optional: Multi-Step Sequence")]
    [TextArea] public string[] sequenceTexts;

    private int sequenceIndex = -1;  // Start bei -1 = vor dem ersten Text

    public bool hasSequence =>
        sequenceTexts != null && sequenceTexts.Length > 0;

    // Gibt den aktuellen Text (ohne den Index zu ändern)
    public string GetText()
    {
        // keine Sequenz → normale Interaktion
        if (!hasSequence)
            return interactionText;

        // wenn noch kein Schritt gestartet wurde
        if (sequenceIndex < 0)
            return sequenceTexts[0];

        // falls etwas schief gelaufen ist
        if (sequenceIndex >= sequenceTexts.Length)
            return "";

        return sequenceTexts[sequenceIndex];
    }

    // Gibt den nächsten Text der Sequenz zurück
    public string GetNextSequenceText()
    {
        if (!hasSequence)
            return "";

        sequenceIndex++;

        // Wenn wir am Ende sind → leeren Text liefern
        if (sequenceIndex >= sequenceTexts.Length)
        {
            sequenceIndex = sequenceTexts.Length;
            return "";
        }

        return sequenceTexts[sequenceIndex];
    }

    // Setzt die Sequenz zurück (z. B. beim Neu-Ansprechen)
    public void ResetSequence()
    {
        sequenceIndex = -1;
    }

    // Gibt einfach nur an, dass der script von anderen Scripts angesprochen werden kann
    public void Awake()
    {
        instance = this;
    }

    // Hier kommt alles rein wodurch du interaktionen startest welche keine Dialoge sind( wird durch den PlayerInteractions Script angesprochen )
    public void BasicInteraction()
    {
        Debug.Log("Congratulations! You just Interacted with a non Dialogue Object :D");
    }
}
