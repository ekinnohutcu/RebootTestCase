﻿using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class Priz: MonoBehaviour
{
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plug")
        {
            other.gameObject.GetComponent<PuzzlePiece>().isDone = true;
            other.gameObject.GetComponent<PuzzlePiece>().isTriggerEnter= true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plug")
        {
            other.gameObject.GetComponent<PuzzlePiece>().isDone = false;
            other.gameObject.GetComponent<PuzzlePiece>().isTriggerEnter = false;
        }
    }
}
