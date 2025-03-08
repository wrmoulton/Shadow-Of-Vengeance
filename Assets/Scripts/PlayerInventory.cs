using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;  // Tracks if the player has collected the key
    public bool hasCard = false; // Tracks if the player has collected the card

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for Key Pickup
        if (other.CompareTag("Key") && !hasKey)
        {
            hasKey = true;
            Destroy(other.gameObject); // Remove the key from the scene
            Debug.Log("Key collected!");
        }

        // Check for Card Pickup
        if (other.CompareTag("Card") && !hasCard)
        {
            hasCard = true;
            Destroy(other.gameObject); // Remove the card from the scene
            Debug.Log("Card collected!");
        }
    }
}
