using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject doorPartToDisable; // Assign tilesStuff_43 in the Inspector
    public AudioSource doorSound;
    private bool isUnlocked = false; // Prevents multiple triggers

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (!isUnlocked && playerInventory != null && playerInventory.hasKey) // Check if the player has the key
        {
             Debug.Log("Player has the key! Opening the door...");
            OpenDoor();
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
}
