using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PianoPuzzle : MonoBehaviour
{
    public GameObject pianoUI;
    public AudioClip[] noteClips;
    public AudioClip successSound;
    public int[] correctSequence;
    
    AudioSource audioSource;
    List<int> playerSequence = new List<int>();
    bool puzzleActive;
    bool puzzleSolved;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pianoUI.SetActive(false);
    }

    void Update()
    {
        if(!puzzleActive || puzzleSolved)
            return;
        
        if(Keyboard.current.digit1Key.wasPressedThisFrame) PlayNote(1);
        if(Keyboard.current.digit2Key.wasPressedThisFrame) PlayNote(2);
        if(Keyboard.current.digit3Key.wasPressedThisFrame) PlayNote(3);
        if(Keyboard.current.digit4Key.wasPressedThisFrame) PlayNote(4);
        if(Keyboard.current.digit5Key.wasPressedThisFrame) PlayNote(5);
        if(Keyboard.current.digit6Key.wasPressedThisFrame) PlayNote(6);
        if(Keyboard.current.digit7Key.wasPressedThisFrame) PlayNote(7);
        
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
            ClosePuzzle();
    }

    public void OpenPuzzle()
    {
        if(puzzleSolved)
            return;
        puzzleActive = true;
        pianoUI.SetActive(true);
        playerSequence.Clear();
        GameManager.instance.StopMusic();
    }

    public void ClosePuzzle()
    {
        puzzleActive = false;
        pianoUI.SetActive(false);
        if(!puzzleSolved)
            GameManager.instance.ResumeMainMusic();
    }

    void PlayNote(int noteNumber)
    {
        int index = noteNumber - 1;
        if(index < noteClips.Length)
            audioSource.PlayOneShot(noteClips[index]);
        
        playerSequence.Add(noteNumber);
        
        if(playerSequence.Count >= correctSequence.Length)
            CheckSequence();
    }

    void CheckSequence()
    {
        bool correct = true;
        for(int i = 0; i < correctSequence.Length; i++)
        {
            if(playerSequence[i] != correctSequence[i])
                correct = false;
        }

        if(correct)
        {
            puzzleSolved = true;
            GameManager.instance.puzzle1Solved = true;
            
            if(successSound != null)
                audioSource.PlayOneShot(successSound);
            
            Invoke("FinishPuzzle", 1f);
        }
        else
        {
            playerSequence.Clear();
        }
    }

    void FinishPuzzle()
    {
        GameManager.instance.ResumeMainMusic();
        ClosePuzzle();
    }
}
