using UnityEngine;
using UnityEngine.InputSystem;

public class PianoTrigger : MonoBehaviour
{
    public PianoPuzzle pianoPuzzle;
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
            if(GameManager.instance.allNotesCollected && !GameManager.instance.puzzle1Solved)
                pianoPuzzle.OpenPuzzle();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = true;
            if(GameManager.instance.allNotesCollected && !GameManager.instance.puzzle1Solved)
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
