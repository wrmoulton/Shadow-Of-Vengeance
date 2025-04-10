using UnityEngine;
using TMPro;

public class DoorKey : MonoBehaviour
{
    public GameObject doorPartToDisable; // Assign tilesStuff_43 in the Inspector
    public AudioSource doorSound;
    private bool isUnlocked = false; // Prevents multiple triggers
    public TMP_Text messageText; // Assign in Inspector
    public float messageDuration = 2f; // How long the message shows

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (!isUnlocked && playerInventory != null && playerInventory.hasKey) // Check if the player has the key
        {
             Debug.Log("Player has the key! Opening the door...");
            OpenDoor();
        }
        else
        {
            Debug.Log("Player doesn't have key!");
            DoorClosed();
        }
    }

    void OpenDoor()
    {
        isUnlocked = true;
        if (doorPartToDisable != null)
        {
            doorPartToDisable.SetActive(false); // Disables the door object
        }
        // Play the sound effect
        if (doorSound != null)
        {
            doorSound.Play();
        }
    }
    void DoorClosed()
    {
        if (messageText != null)
        {
            messageText.text = "The door is locked. You need a key!";
            CancelInvoke(nameof(ClearMessage));
            Invoke(nameof(ClearMessage), messageDuration); // Clear after a delay
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
