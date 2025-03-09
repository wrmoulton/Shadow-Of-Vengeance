using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string Level1 = "Level-1"; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("scientist"))
        { // Make sure your player has the "Player" tag
            SceneManager.LoadScene(Level1);
        }
    }
}