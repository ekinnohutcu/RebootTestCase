using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class PlugInputHandler : MonoBehaviour
{

    public GameObject plugHead;
    
   
    // Start is called before the first frame update
    void Start()
    {
        LeanTouch.OnFingerSet += OnFingerSet;
        LeanTouch.OnFingerUp += OnFingerUp;
    }
    

    private void OnFingerSet(LeanFinger finger)
    {
        
        
    }

    private void OnFingerUp(LeanFinger obj)
    {
        
    }
    
    private void OnDisable()
    {
        LeanTouch.OnFingerSet -= OnFingerSet;
    }
}
