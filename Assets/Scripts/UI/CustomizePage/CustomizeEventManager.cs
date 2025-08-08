using System;
using UnityEngine;

namespace UI.CustomizePage
{
    public class CustomizeEventManager : MonoBehaviour
    {
        public static CustomizeEventManager Instance { get; private set; }

        public event Action<int> OnPurchaseClicked;
        public event Action<int> OnSelectClicked;
        
        private void Awake()
        {
            Instance ??= this;
        }

        public void OnPurchaseBtnClicked(int index) => OnPurchaseClicked?.Invoke(index);
        
        public void OnSelectBtnClicked(int index) => OnSelectClicked?.Invoke(index);
    }
}