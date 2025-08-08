using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GaragePage.Item
{
    public class CarItem : MonoBehaviour
    {
        public Button btn;
        public GameObject bgOpen;
        public GameObject bgLock;
        public Image icon;

        private int _id;

        public void Init(int index)
        {
            _id = index;
            RefreshButton();
            InitButton(_id);
            InitObject(_id);
        }

        public void OnDestroy()
        {
            RefreshButton();
        }

        public void InitObject(int index)
        {
            icon.sprite = VehicleData.Instance.vehicles[index].icon;
            var unlocked = DataManager.GetUnlockState(VehicleData.Instance.vehicles[index].name) == 1 || VehicleData.Instance.vehicles[index].isUnlocked;
            bgOpen.SetActive(unlocked);
            bgLock.SetActive(!unlocked);
        }

        public void RefreshButton()
        {
            GarageEventManager.Instance.OnPurchaseClicked -= HandleClick;
            btn.onClick.RemoveAllListeners();
        }
        
        public void InitButton(int index)
        {
            GarageEventManager.Instance.OnPurchaseClicked += HandleClick;
            btn.onClick.AddListener(() => GarageEventManager.Instance.OnCarItemBtnClicked(index));
        }
        
        public void HandleClick(int index)
        {
            if(_id != index) return;
            bgOpen.SetActive(true);
            bgLock.SetActive(false);
        }
    }
}