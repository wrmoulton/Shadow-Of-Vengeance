using UnityEngine;
using TMPro;

public class OneTimeAreaMessage : MonoBehaviour
{
    public TMP_Text messageText; // Assign your UI Text object in the Inspector
    public string messageToShow = "Looks like this grate reacts to weight. Maybe it triggers something?"; // Customize message
    public float messageDuration = 5f; // How long the message stays on screen

    private bool hasShownMessage = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only trigger once and only for objects with PlayerInventory (like your door uses)
        if (!hasShownMessage && other.GetComponent<PlayerInventory>() != null)
        {
            hasShownMessage = true;
            ShowMessage();
        }
    }

    void ShowMessage()
    {
        if (messageText != null)
        {
            messageText.text = messageToShow;
            CancelInvoke(nameof(ClearMessage));
            Invoke(nameof(ClearMessage), messageDuration);
        }
    }

    void ClearMessage()
    {
        if (messageText != null)
        {
            messageText.text = "";
        }
    }
}
