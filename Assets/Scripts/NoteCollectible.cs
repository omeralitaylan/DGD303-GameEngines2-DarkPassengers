using UnityEngine;
using UnityEngine.InputSystem;

public class NoteCollectible : MonoBehaviour
{
    public GameObject notePanel;
    public GameObject eIcon;
    bool playerNear;
    bool isOpen;

    void Start()
    {
        notePanel.SetActive(false);
        eIcon.SetActive(false);
    }

    void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(isOpen)
                CloseNote();
            else if(playerNear)
                OpenNote();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = true;
            if(!isOpen)
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

    void OpenNote()
    {
        isOpen = true;
        eIcon.SetActive(false);
        notePanel.SetActive(true);
        GameManager.instance.OnFirstNoteOpened();
    }

    void CloseNote()
    {
        isOpen = false;
        notePanel.SetActive(false);
        NoteManager.instance.CollectNote();
        Destroy(gameObject);
    }
}
