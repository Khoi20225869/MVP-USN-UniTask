using System;
using Cysharp.Threading.Tasks;
using Data;
using UI.GaragePage.Item;
using UnityEngine;
using UnityEngine.UI;
using UI.Object.Text;

namespace UI.GaragePage
{
    public class GarageView : MonoBehaviour
    {
        public float delaySeconds;
        public Button purchaseBtn;
        public Button customizeBtn;
        public Button selectBtn;

        public Transform content;
        public GameObject carItemPrefab;
        
        public void Init()
        {
            RefreshButton();
            InitButton();
            SpawnCarItemsAsync(VehicleData.Instance.vehicles.Length).Forget();
        }

        private async UniTask SpawnCarItemsAsync(int count)
        {
            var token = this.GetCancellationTokenOnDestroy();
            await UniTask.Delay(
                TimeSpan.FromSeconds(delaySeconds),
                cancellationToken: token
            );
            await UniTask.Delay(
                TimeSpan.FromSeconds(delaySeconds),
                cancellationToken: token
            );
            for (var i = 0; i < count; i++)
            {
                var carItem = Instantiate(carItemPrefab, content);
                carItem.GetComponent<CarItem>().Init(i);
                await UniTask.Delay(
                    TimeSpan.FromSeconds(delaySeconds),
                    cancellationToken: token
                );
            }
        }
        private void OnDestroy()
        {
            RefreshButton();
        }

        private void InitButton()
        {
            purchaseBtn.onClick.AddListener(() =>
            {
                GarageEventManager.Instance.OnPurchaseBtnClicked(GarageManager.GetCurrentVehicleGarageIndex());
                TxtEventManager.Instance.OnMoneyTextChanged();
            });
            customizeBtn.onClick.AddListener(GarageEventManager.Instance.OnCustomizeBtnClicked);
            selectBtn.onClick.AddListener(GarageEventManager.Instance.OnSelectedBtnClicked);
        }

        private void RefreshButton()
        {
            purchaseBtn.onClick.RemoveAllListeners();
            customizeBtn.onClick.RemoveAllListeners();
            selectBtn.onClick.RemoveAllListeners();
        }
    }
}