using UnityEngine;
using System;

namespace UI.MainPage
{
    public class MainEventManager : MonoBehaviour
    {
        public static MainEventManager Instance { get; private set; }

        public event Action OnPlayClicked;
        public event Action OnPauseClicked;
        public event Action OnGarageClicked;
        private void Awake()
        {
            Instance ??= this;
        }
        
        public void OnPlayBtnClicked() => OnPlayClicked?.Invoke();
    
        public void OnPauseBtnClicked() => OnPauseClicked?.Invoke();
    
        public void OnGarageBtnClicked() => OnGarageClicked?.Invoke();
    }
}