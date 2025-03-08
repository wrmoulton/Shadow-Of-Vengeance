using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton pattern to ensure only one instance exists
    public AudioSource musicSource; // Background music source
    public AudioClip backgroundMusic; // Assign this in the Inspector

    void Awake()
    {
        // Singleton pattern to prevent duplicates
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensures AudioManager persists across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Assign the AudioSource component
        musicSource = GetComponent<AudioSource>();

        if (musicSource == null)
        {
            Debug.LogError("AudioSource component missing from AudioManager! Adding one now.");
        }

        // If background music is assigned, play it
        if (backgroundMusic != null)
        {
            PlayMusic(backgroundMusic);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return; // Prevent restarting same track
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
