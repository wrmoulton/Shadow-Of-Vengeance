using UnityEngine;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    public Animator doorAnimator; // Assign the door's Animator in the Inspector
    public GameObject OpenDoor;
    public GameObject ClosedDoor;
    public AudioSource doorSound; // Reference to the AudioSource component
    private bool isUnlocked = false; // Prevents multiple triggers

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!isUnlocked)
        {
            Unlock();
            Debug.Log("Playing Anim");
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
}
