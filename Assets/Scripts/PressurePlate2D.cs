using UnityEngine;

public class PressurePlate2D : MonoBehaviour
{
    public GameObject closedChest; // Assign "props and items x3_51" (Closed Chest)
    public GameObject openChest;   // Assign "chest_keys_treasure_34" (Open Chest)
    public string requiredTag = "PressureBox"; // Object that activates the plate
    private int objectsOnPlate = 0; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag))
        {
            objectsOnPlate++;
            UpdateChestState();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag))
        {
            objectsOnPlate--;
            UpdateChestState();
        }
    }

    private void UpdateChestState()
    {
        if (closedChest != null && openChest != null)
        {
            bool isActive = objectsOnPlate > 0;
            closedChest.SetActive(!isActive); // Hide closed chest if activated
            openChest.SetActive(isActive);    // Show open chest if activated
        }
    }
}
