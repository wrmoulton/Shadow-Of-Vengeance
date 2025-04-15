using UnityEngine;
using TMPro;

public class CardReader : MonoBehaviour
{
    public Animator doorAnimator; // Assign the door's Animator in the Inspector
    public GameObject OpenDoor;
    public GameObject ClosedDoor;
    public AudioSource doorSound; // Reference to the AudioSource component
    private bool isUnlocked = false; // Prevents multiple triggers
    public TMP_Text messageText; // Assign in Inspector
    public float messageDuration = 2f; // How long the message shows

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (!isUnlocked && playerInventory != null && playerInventory.hasKeyCard)
        {
            Unlock();
            Debug.Log("Playing Anim");
        }
         else
         {
            Debug.Log("Player doesn't have key!");
            DoorClosed();
         }
    }

    void Unlock()
    {
        isUnlocked = true; // Mark door as opened
        if (doorAnimator != null)
        {
            OpenDoor.SetActive(false);
            doorAnimator.SetTrigger("Open"); // Play the door open animation
            ClosedDoor.SetActive(true);
        }
        // Play the sound effect
        if (doorSound != null)
        {
            doorSound.Play();
        }
        Debug.Log("Door is now open!");
    }
    void DoorClosed()
    {
        if (messageText != null)
        {
            messageText.text = "The door is locked. You need a keycard!";
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
