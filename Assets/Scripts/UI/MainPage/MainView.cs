using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainPage
{
    public class MainView : MonoBehaviour
    {
        public Button garageBtn;
        public Button playBtn;
        public Button achievementBtn;

        public void Init()
        {
            Refresh();
            InitButton();
        }
        private void OnDestroy()
        {
            Refresh();
        }

        private void InitButton()
        {
            garageBtn.onClick.AddListener(MainEventManager.Instance.OnGarageBtnClicked);
            playBtn.onClick.AddListener(MainEventManager.Instance.OnPlayBtnClicked);
            achievementBtn.onClick.AddListener(MainEventManager.Instance.OnPauseBtnClicked);
        }

        private void Refresh()
        {
            garageBtn.onClick.RemoveAllListeners();
            playBtn.onClick.RemoveAllListeners();
            achievementBtn.onClick.RemoveAllListeners();
        }
    }
}