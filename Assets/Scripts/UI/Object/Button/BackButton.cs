using UnityEngine;
using UnityEngine.UI;
namespace UI.Object
{
    public class BackButton : MonoBehaviour
    {
        public Button backBtn;

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
            backBtn.onClick.AddListener(OnButtonClicked);
        }

        private void RefreshButton()
        {
            backBtn.onClick.RemoveAllListeners();
        }
        
        private void OnButtonClicked()
        {
           _ = TransitionService.TransitionBackPage();
        }
    }
}