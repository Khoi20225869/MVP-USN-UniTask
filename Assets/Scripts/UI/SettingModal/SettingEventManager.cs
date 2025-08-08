using UnityEngine;
using System;
namespace UI.SettingModal
{
    public class SettingEventManager : MonoBehaviour
    {
        public static SettingEventManager Instance { get; private set; }
        
        public Action<float> OnSoundChanged;
        public Action<float> OnMusicChanged;
        public Action OnBackClicked;

        private void Awake()
        {
            Instance ??= this;
        }

        public void OnSlideSoundChanged(float value) => OnSoundChanged?.Invoke(value);
        public void OnSlideMusicChanged(float value) => OnMusicChanged?.Invoke(value);
        public void OnBackButtonClicked() => OnBackClicked.Invoke();
        //public void OnOptionLanguageChanged() => OnLanguageChanged?.Invoke();
    }
}

