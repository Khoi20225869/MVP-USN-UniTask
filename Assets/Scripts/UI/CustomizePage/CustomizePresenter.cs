using UnityEngine;

namespace UI.CustomizePage
{
    public class CustomizePresenter
    {
        private readonly CustomizeView _view;
        
        public CustomizePresenter(CustomizeView view)
        {
            _view = view;
            Init();
        }

        private void Init()
        {
            CustomizeEventManager.Instance.OnSelectClicked += HandleSelectClicked;
            CustomizeEventManager.Instance.OnPurchaseClicked += HandlePurchaseClicked;
        }

        public void Release()
        {
            CustomizeEventManager.Instance.OnSelectClicked -= HandleSelectClicked;
            CustomizeEventManager.Instance.OnPurchaseClicked -= HandlePurchaseClicked;
        }

        private void HandleSelectClicked(int index)
        {
            Debug.Log($"Selected index: {index}");
        }
        
        private void HandlePurchaseClicked(int index)
        {
            Debug.Log($"Purchased index: {index}");
        }
    }
}