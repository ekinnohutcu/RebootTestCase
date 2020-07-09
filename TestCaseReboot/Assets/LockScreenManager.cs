using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Reboot
{
    public class LockScreenManager : MonoBehaviour
    {
        //3 correct pattern to pass the level
        [SerializeField] private List<PasswordData> _patterns;
        
        public GameObject continueButton;
        public GameObject tryAgainButton;

        private int _lives = 3;
        private int _currentPatternIndex = 0;
    
        private void Start()
        {
            continueButton.SetActive(false);
            tryAgainButton.SetActive(false);
        }

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

        public void CheckPassword(int[] enteredPassword)
        {
            var correctPattern = _patterns[_currentPatternIndex].data;
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

    [System.Serializable]
    public struct PasswordData
    {
        public int[] data;
    }
}