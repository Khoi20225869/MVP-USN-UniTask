using UnityEngine;

namespace UI
{
    public class EntryStart : MonoBehaviour
    {
        private void Start()
        {
            _ = TransitionService.TransitionToMainPage();
        }
    }
}