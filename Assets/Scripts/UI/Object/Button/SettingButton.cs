using UnityEngine;
using UnityEngine.UI;

namespace UI.Object
{
    public class SettingButton : MonoBehaviour
    {
        public Button settingBtn;

        private void Start()
        {
            RefreshButton();
            InitButton();
        }

        private void OnDestroy()
        {
            RefreshButton();
        }
        
        private void InitButton()
        {
            settingBtn.onClick.AddListener(OnButtonClicked);
        }

        private void RefreshButton()
        {
            settingBtn.onClick.RemoveAllListeners();
        }
        
        private void OnButtonClicked()
        {
            Debug.Log("Button clicked");
            _ = TransitionService.TransitionToSettingModal();
        }
    }
}