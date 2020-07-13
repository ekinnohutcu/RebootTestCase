using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lean.Touch;
using UnityEngine;

public class PlugManager : MonoBehaviour
{
    
   // private int _plugCount = 0;


   //UI elements
    public GameObject winText;
    public GameObject levelObjects;
    
    //list that contains all pieces.
    public List<PuzzlePiece> piece;

    //boolean to check user's finger is on screen or not.
    private bool isFingerUp;

    
    //private int count;

    //list that contains plugs on priz.
    public List<PuzzlePiece> prizList;
    
    
    
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

    
    void Update()
    {
        foreach (var puzzlePiece in piece)
        {
            if (puzzlePiece.isDone)
            {
                prizList.Add(puzzlePiece);
                puzzlePiece.isDone = false;
            }

            if (!puzzlePiece.isTriggerEnter)
            {
                prizList.Remove(puzzlePiece);
            }
        }
        
        if(piece.All(prizList.Contains))
            Win();
    }

    
    //if user enters all prizes correctly.
    public void Win()
    {
        levelObjects.SetActive(false);
        winText.SetActive(true);
    }

    //LeanTouch
    private void OnDisable()
    {
        LeanTouch.OnFingerSet -= OnFingerSet;
        LeanTouch.OnFingerUp -= OnFingerUp;
    }
}
