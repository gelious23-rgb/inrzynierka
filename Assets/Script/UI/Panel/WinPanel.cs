using UnityEngine;

namespace Script.UI.Panel
{
    public class WinPanel: MonoBehaviour , IPanel
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}