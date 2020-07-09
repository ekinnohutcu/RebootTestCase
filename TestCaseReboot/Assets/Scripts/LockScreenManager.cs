using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Reboot
{
    public class LockScreenManager : MonoBehaviour
    {
        //3 correct pattern to pass the level
        [SerializeField] private List<PasswordData> _patterns;
        
        public GameObject continueButton; //continue to next level
        public GameObject tryAgainButton; //try again if fail 3 times

        private int _lives = 3; //3 lives for user
        private int _currentPatternIndex = 0; //correct password indexes 
    
        private void Start()
        {
            continueButton.SetActive(false);
            tryAgainButton.SetActive(false);
        }

        //if user failes, call this function. it will decrease lives by one.
        public void Failed()
        {
            if (--_lives <= 0)
            {
                tryAgainButton.SetActive(true);
            }
            else
            {
                Debug.Log($"lives: {_lives}");
            }
        }

        //this method is calling from InputHandler class and checks the user input and correct passwords are equal or not.
        public void CheckPassword(int[] enteredPassword)
        {
            var correctPattern = _patterns[_currentPatternIndex].data;
            
            //if lengths are not equal
            if (enteredPassword.Length != correctPattern.Length)
            {
                Failed();
                return;
            }
            else
            {
                for (var i = 0; i < correctPattern.Length; i++)
                {
                    if (correctPattern[i] != enteredPassword[i])
                    {
                        Failed();
                        return;
                    }
                }
            }

            _currentPatternIndex++;
            if (_currentPatternIndex >= 3)
            {
                LevelUnlocked();
            }
        }

        private void LevelUnlocked()
        {
            continueButton.SetActive(true);
        }

        public void Continue()
        {
            SceneManager.LoadScene("Level2");
        }

        public void TryAgain()
        {
            SceneManager.LoadScene("Level1");
        }
    }

    //correct passwords in an integer struct (initially 3 of them but we can expand from inspector)
    [System.Serializable]
    public struct PasswordData
    {
        public int[] data;
    }
}