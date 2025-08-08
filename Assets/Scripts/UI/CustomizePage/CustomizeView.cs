using UnityEngine;
using UnityEngine.UI;
namespace UI.CustomizePage
{
    public class CustomizeView : MonoBehaviour
    {
        public Button purchaseBtn;
        public Button selectBtn;
        public void Init()
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
            purchaseBtn.onClick.AddListener(() => CustomizeEventManager.Instance.OnPurchaseBtnClicked(0));
            selectBtn.onClick.AddListener(() => CustomizeEventManager.Instance.OnSelectBtnClicked(0));
        }

        private void RefreshButton()
        {
            purchaseBtn.onClick.RemoveAllListeners();
            selectBtn.onClick.RemoveAllListeners();
        }
    }
}