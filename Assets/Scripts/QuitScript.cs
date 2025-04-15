using UnityEngine;

public class QuitScript : MonoBehaviour
{
    // Method to quit the game, called via a UI button
    public void QuitGame()
    {
        // Quit the game (only works in a built application)
        Application.Quit();
    }
}

