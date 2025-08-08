using UnityEngine;

namespace UI.SettingModal
{
    public class SettingPresenter
    {
        private readonly SettingView _view;
        
        public SettingPresenter(SettingView view)
        {
            _view = view;
            Init();
        }

        private void Init()
        {
            SettingEventManager.Instance.OnSoundChanged += HandleSoundChanged;
            SettingEventManager.Instance.OnMusicChanged += HandleMusicChanged;
            SettingEventManager.Instance.OnBackClicked += HandleSettingBackButtonClicked;
        }
        
        public void Release()
        {
            SettingEventManager.Instance.OnSoundChanged -= HandleSoundChanged;
            SettingEventManager.Instance.OnMusicChanged -= HandleMusicChanged;
            SettingEventManager.Instance.OnBackClicked -= HandleSettingBackButtonClicked;
        }
        
        private void HandleSoundChanged(float value)
        {
            _view.sliderSound.value = value;
            Debug.Log($"Sound changed to: {value}");
        }
        
        private void HandleMusicChanged(float value)
        {
            _view.sliderMusic.value = value;
            Debug.Log($"Music changed to: {value}");
        }
        
        private void HandleSettingBackButtonClicked()
        {
            _ = TransitionService.TransitionBackModal();
        }
    }
}