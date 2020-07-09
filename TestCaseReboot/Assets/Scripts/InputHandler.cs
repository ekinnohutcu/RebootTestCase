using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

namespace Reboot
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private LockScreenManager _lockScreenManager;
    
        public List<LockButton> selectedLockButtons = new List<LockButton>();
    
        private bool buttonPressed = false;

        private void Start()
        {
            LeanTouch.OnFingerSet += OnFingerSet;
            LeanTouch.OnFingerUp += OnFingerUp;
        }

        private void OnFingerUp(LeanFinger obj)
        {
            var password = new int[selectedLockButtons.Count];
            for (var i = 0; i < selectedLockButtons.Count; i++)
            {
                password[i] = selectedLockButtons[i].buttonID;
            }

            if(password.Length > 1)
                _lockScreenManager.CheckPassword(password);
        
            foreach (var lockButton in selectedLockButtons)
            {
                lockButton.SelectButton(false);
            }
            selectedLockButtons = new List<LockButton>();
            //reset lines
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
