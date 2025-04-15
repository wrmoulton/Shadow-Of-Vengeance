using UnityEngine;

public class LinkedPressurePlate : MonoBehaviour
{
    public GameObject closedChest;
    public GameObject openChest;
    public string requiredTag = "PressureBox";

    private static int totalPlatesPressed = 0;
    private static int requiredPlates = 2;

    private bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPressed && other.CompareTag(requiredTag))
        {
            isPressed = true;
            totalPlatesPressed++;
            UpdateChestState();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isPressed && other.CompareTag(requiredTag))
        {
            isPressed = false;
            totalPlatesPressed = Mathf.Max(0, totalPlatesPressed - 1);
            UpdateChestState();
        }
    }

    private void UpdateChestState()
    {
        bool shouldBeOpen = totalPlatesPressed >= requiredPlates;

        if (closedChest != null)
            closedChest.SetActive(!shouldBeOpen);

        if (openChest != null)
            openChest.SetActive(shouldBeOpen);
    }
}
