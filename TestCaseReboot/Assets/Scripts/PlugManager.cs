using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class PlugManager : MonoBehaviour
{
    
    private int _plugCount = 0;


    public GameObject winText;
    public GameObject levelObjects;
    public List<PuzzlePiece> piece;

    private bool isFingerUp;
    
    
    
    void Start()
    {
        LeanTouch.OnFingerSet += OnFingerSet;
        LeanTouch.OnFingerUp += OnFingerUp;
        winText.SetActive(false);
    }

    private void OnFingerUp(LeanFinger finger)
    {
        isFingerUp = true;
    }
    
    private void OnFingerSet(LeanFinger finger)
    {
        isFingerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var puzzlePiece in piece)
        {
            if (puzzlePiece.isDone && isFingerUp)
            {
                Win();
            }
        }
    }

    public void Win()
    {
        levelObjects.SetActive(false);
        winText.SetActive(true);
    }
    
    
}
