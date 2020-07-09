using UnityEngine;

namespace Reboot
{
    public class LockButton : MonoBehaviour
    {
        public int buttonID;
        [HideInInspector] public bool isSelected;

        public void SelectButton(bool selected)
        {
            isSelected = selected;
        }
    }
}