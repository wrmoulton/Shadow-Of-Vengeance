using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string LevelOne; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("scientist"))
        { // Make sure your player has the "Player" tag
            SceneManager.LoadScene(LevelOne);
        }
    }
}