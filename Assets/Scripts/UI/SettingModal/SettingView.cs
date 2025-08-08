using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SettingModal
{
    public class SettingView : MonoBehaviour
    {
        public Button backButton;
        public Slider sliderSound;
        public Slider sliderMusic;
        
        public void Init()
        {
            Refresh();
            InitSlider();
        }

        private void OnDestroy()
        {
            Refresh();
        }

        private void InitSlider()
        {
            sliderSound.onValueChanged.AddListener((index) =>SettingEventManager.Instance.OnSlideSoundChanged(index));
            sliderMusic.onValueChanged.AddListener((index) => SettingEventManager.Instance.OnSlideMusicChanged(index));
            backButton.onClick.AddListener(() => SettingEventManager.Instance.OnBackButtonClicked());
        }

        private void Refresh()
        {
            sliderSound.onValueChanged.RemoveAllListeners();
            sliderMusic.onValueChanged.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
        }
        
    }
}