using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject doorPartToDisable; // Assign tilesStuff_43 in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null && playerInventory.hasKey) // Check if the player has the key
        {
             Debug.Log("Player has the key! Opening the door...");
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (doorPartToDisable != null)
        {
            doorPartToDisable.SetActive(false); // Disables the door object
        }
    }
}
