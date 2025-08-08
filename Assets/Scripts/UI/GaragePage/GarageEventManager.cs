using UnityEngine;
using System;

namespace UI.GaragePage
{
    public class GarageEventManager : MonoBehaviour
    {
        public static GarageEventManager Instance { get; private set; }

        public event Action<int> OnCarItemClicked;
        public event Action<int> OnPurchaseClicked;
        public event Action OnCustomizeClicked;
        public event Action OnSelectedClicked;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
        public void OnCarItemBtnClicked(int index) => OnCarItemClicked?.Invoke(index);
        
        public void OnPurchaseBtnClicked(int index) => OnPurchaseClicked?.Invoke(index);
        
        public void OnCustomizeBtnClicked() => OnCustomizeClicked?.Invoke();

        public void OnSelectedBtnClicked() => OnSelectedClicked?.Invoke();
    }
}