using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public SpriteRenderer laserRenderer; // Drag your laser sprite here
    public string blockingTag = "PressureBox";
    public float disableDuration = 1.0f; // How long laser stays off after being blocked
    public GameObject gameOverScreen;   // Assign this in the Inspector
    private float disableTimer = 0f;
    public AudioSource Audio;

    void Update()
    {
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, 50f);
        bool justBlocked = false;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider == null) continue;

            if (hit.collider.CompareTag(blockingTag))
            {
                justBlocked = true;
                break;
            }

            if (hit.collider.CompareTag("Player") && disableTimer <= 0f)
            {
                Debug.Log("Laser hit the player!");
                TriggerGameOver();
                break;
            }
        }

        // Mute or unmute the audio based on whether the laser is blocked
        if (Audio != null)
        {
            Audio.mute = justBlocked;
        }

        // If just blocked, reset the timer
        if (justBlocked)
        {
            disableTimer = disableDuration;
        }

        // Decrease the timer
        if (disableTimer > 0f)
        {
            disableTimer -= Time.deltaTime;
        }

        // Enable or disable laser based on timer
        if (laserRenderer != null)
        {
            laserRenderer.enabled = disableTimer <= 0f;
        }
    }

    void TriggerGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Show Game Over screen
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // No need to reset time here anymore
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
