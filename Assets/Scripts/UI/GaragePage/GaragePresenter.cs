using UnityEngine;

namespace UI.GaragePage
{
    public class GaragePresenter
    {
        private readonly GarageView _view;

        public GaragePresenter(GarageView view)
        {
            _view = view;
            Init();
        }
        private void Init()
        {
            GarageEventManager.Instance.OnCarItemClicked += HandleCarItemClicked;
            GarageEventManager.Instance.OnPurchaseClicked += HandlePurchaseClicked;
            GarageEventManager.Instance.OnSelectedClicked += HandleSelectedClicked;
            GarageEventManager.Instance.OnCustomizeClicked += HandleCustomizeClicked;
        }

        public void Release()
        {
            GarageEventManager.Instance.OnCarItemClicked -= HandleCarItemClicked;
            GarageEventManager.Instance.OnPurchaseClicked -= HandlePurchaseClicked;
            GarageEventManager.Instance.OnSelectedClicked -= HandleSelectedClicked;
            GarageEventManager.Instance.OnCustomizeClicked -= HandleCustomizeClicked;
        }
        
        private void HandleCarItemClicked(int carId)
        {
            GarageManager.InitBtnGarageState(carId, _view.purchaseBtn, _view.customizeBtn, _view.selectBtn);
        }

        private void HandlePurchaseClicked(int index)
        {
            GarageManager.ClickPurchaseBtn(_view.purchaseBtn, _view.customizeBtn, _view.selectBtn);
        }
        
        private void HandleSelectedClicked()
        {
            Debug.Log($"Car with ID selected.");
        }
        
        private void HandleCustomizeClicked()
        {
            _ = TransitionService.TransitionToCustomizePage();
        }
    }
}