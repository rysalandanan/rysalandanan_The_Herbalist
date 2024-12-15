using TMPro;
using UnityEngine;
using System.Collections;
public class TypeEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent; // Assign your TextMeshPro component here
    [SerializeField] private float typingSpeed; // Time delay between each character

    private string fullText; // The full text to display
    private bool isTyping = false;

    private void Start()
    {
        // Grab the initial text from the component and clear it
        if (textComponent == null)
        {
            Debug.LogError("Text Component not assigned!");
            return;
        }

        fullText = textComponent.text;
        textComponent.text = ""; // Start with an empty display

        // Start the typewriter effect
        StartCoroutine(TypeText());
    }
    private IEnumerator TypeText()
    {
        isTyping = true;
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed); // Delay for typing effect
        }
        isTyping = false;
    }
    public bool IsTyping()
    {
        return isTyping; // Returns whether typing is still in progress
    }
}
