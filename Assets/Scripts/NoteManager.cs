using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;
    public int totalNotes = 4;
    public int collectedNotes = 0;

    void Awake()
    {
        instance = this;
    }

    public void CollectNote()
    {
        collectedNotes++;
        GameManager.instance.collectedNotes = collectedNotes;
        
        if(collectedNotes >= totalNotes)
            GameManager.instance.allNotesCollected = true;
    }
}
