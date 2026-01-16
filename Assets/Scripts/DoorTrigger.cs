using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public GameObject eIcon;
    bool playerNear;

    void Start()
    {
        eIcon.SetActive(false);
    }

    void Update()
    {
        if(playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(GameManager.instance.puzzle1Solved)
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentScene + 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = true;
            if(GameManager.instance.puzzle1Solved)
                eIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = false;
            eIcon.SetActive(false);
        }
    }
}
