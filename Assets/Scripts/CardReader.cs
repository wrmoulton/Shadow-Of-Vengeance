using UnityEngine;

public class CardReader : MonoBehaviour
{
    public Animator doorAnimator; // Assign the door's Animator in the Inspector
    public GameObject OpenDoor;
    public GameObject ClosedDoor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null && playerInventory.hasCard)
        {
            Unlock();
            Debug.Log("Playing Anim");
        }
    }

    void Unlock()
    {
        if (doorAnimator != null)
        {
            OpenDoor.SetActive(false);
            doorAnimator.SetTrigger("Open"); // Play the door open animation
            ClosedDoor.SetActive(true);
        }

        Debug.Log("Door is now open!");
    }
}
