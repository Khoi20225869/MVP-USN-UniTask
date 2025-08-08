using System;
using UnityEngine;

namespace UI.Object.Text
{
    public class TxtEventManager : MonoBehaviour
    {
        public static TxtEventManager Instance { get; private set; }
        
        public Action OnMoneyChanged;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void OnMoneyTextChanged() => OnMoneyChanged?.Invoke();
    }
}