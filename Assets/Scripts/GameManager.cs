using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool allNotesCollected;
    public bool puzzle1Solved;
    public int collectedNotes;
    
    public AudioSource musicSource;
    public AudioClip mainMusic;
    public AudioClip afterNoteMusic;
    bool firstNoteOpened;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(musicSource != null && mainMusic != null)
        {
            musicSource.clip = mainMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void OnFirstNoteOpened()
    {
        if(!firstNoteOpened && musicSource != null && afterNoteMusic != null)
        {
            firstNoteOpened = true;
            musicSource.Stop();
            musicSource.clip = afterNoteMusic;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        AudioSource[] allAudio = FindObjectsOfType<AudioSource>();
        foreach(AudioSource audio in allAudio)
        {
            if(audio != null)
                audio.Pause();
        }
    }

    public void ResumeMainMusic()
    {
        if(musicSource != null && mainMusic != null)
        {
            musicSource.clip = mainMusic;
            musicSource.Play();
        }
    }

    public void RestartGame()
    {
        allNotesCollected = false;
        puzzle1Solved = false;
        collectedNotes = 0;
        firstNoteOpened = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
