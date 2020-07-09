using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;

namespace Reboot
{
    public class InputHandler : MonoBehaviour
    {
        //instance of a LockScreenManager class.
        [SerializeField] private LockScreenManager _lockScreenManager;
    
        public List<LockButton> selectedLockButtons = new List<LockButton>();
    
        //bool for user touches screen or buttons.
        private bool buttonPressed = false;

        //initialize LeanTouch variables by event functions OnFingerSet and OnFingerUp.
        private void Start()
        {
            LeanTouch.OnFingerSet += OnFingerSet;
            LeanTouch.OnFingerUp += OnFingerUp;
        }

        //when user stop touching screen, this method will save the user's lock pattern into a list then checks is it correct or not.
        private void OnFingerUp(LeanFinger obj)
        {
            var password = new int[selectedLockButtons.Count];
            for (var i = 0; i < selectedLockButtons.Count; i++)
            {
                password[i] = selectedLockButtons[i].buttonID;
            }

            //if there is a password entered, check is it correct or not.
            if(password.Length > 1)
                _lockScreenManager.CheckPassword(password);
        
            
            //reset list
            foreach (var lockButton in selectedLockButtons)
            {
                lockButton.SelectButton(false);
                lockButton.GetComponent<Image>().color = Color.white;
            }
            
            selectedLockButtons = new List<LockButton>();
            
        }

        
        
        private void OnFingerSet(LeanFinger finger)
        {
            var results = LeanTouch.RaycastGui(finger.ScreenPosition);
            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    if (result.gameObject.TryGetComponent(out LockButton lockButton))
                    {
                        if (!lockButton.isSelected)
                        {
                            selectedLockButtons.Add(lockButton);
                            lockButton.SelectButton(true);
                            lockButton.GetComponent<Image>().color = Color.green;
                        }
                    }
                }
            }
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerSet -= OnFingerSet;
        }
    }
}
