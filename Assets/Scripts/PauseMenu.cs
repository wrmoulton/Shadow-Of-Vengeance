using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;

    private bool isPaused = false;

    [SerializeField] private AudioClip buttonClickSound;
    private AudioSource audioSource;


    void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (optionsMenu.activeSelf) // If options is open
            {
                CloseOptions(); // Close it instead of pausing
            }
            else
            {
                TogglePause();
            }
        }
    }


    public void TogglePause(){
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.visible = isPaused;
    }

    public void ResumeGame(){
        TogglePause();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarting Level...");
    }

    public void OpenOptions(){
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitGame(){
        Application.Quit();

        Debug.Log("Exiting Game ...");
    }

    public void CloseOptions(){
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void PlayButtonSound(){
        audioSource.PlayOneShot(buttonClickSound);
    }

}
