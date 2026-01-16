using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject pausePanel;
    bool isPaused;

    void Start()
    {
        if(pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if(Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if(isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        if(pausePanel != null)
            pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        if(pausePanel != null)
            pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
