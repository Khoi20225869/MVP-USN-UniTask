using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public static class GarageManager
    {
        // Garage
        public static int GetCurrentVehicleGarageIndex()
        {
            return DataManager.GetCurrentVehicleGarageIndex();
        }
        public static void InitBtnGarageState(int carId, Button purchaseBtn, Button customizeBtn, Button selectBtn)
        {
            DataManager.SetCurrentVehicleGarageIndex(carId);
            var vehicle = VehicleData.Instance.vehicles[carId];
            var currentMoney = DataManager.GetCurrentMoney();
            SpawnVehicle(carId);
            if (DataManager.GetUnlockState(vehicle.name) == 1 || vehicle.isUnlocked)
            {
                purchaseBtn.gameObject.SetActive(false);
                customizeBtn.gameObject.SetActive(true);
                selectBtn.gameObject.SetActive(true);
            }
            else
            {
                purchaseBtn.gameObject.SetActive(true);
                customizeBtn.gameObject.SetActive(false);
                selectBtn.gameObject.SetActive(false);
                purchaseBtn.interactable = currentMoney >= VehicleData.Instance.vehicles[carId].price;
            }
        }


        public static void ClickPurchaseBtn(Button purchaseBtn, Button customizeBtn, Button selectBtn)
        {
            var currentVehicleGarageIndex = DataManager.GetCurrentVehicleGarageIndex();

            DataManager.SetCurrentMoney(-VehicleData.Instance.vehicles[currentVehicleGarageIndex].price);
            purchaseBtn.gameObject.SetActive(false);
            customizeBtn.gameObject.SetActive(true);
            selectBtn.gameObject.SetActive(true);

            DataManager.SetStateVehicleIndex(VehicleData.Instance.vehicles[currentVehicleGarageIndex].name);
        }

        public static int GetCurrentMoney()
        {
            return DataManager.GetCurrentMoney();
        }
        public static void SpawnVehicle(int carId)
        {
            //$"Spawning vehicle {carId}"
            //$"Destroy vehicle {carId}"
        }
    }


    public static class DataManager
    {
        // Money
        public static int GetCurrentMoney()
        {
            return PlayerPrefs.GetInt("CurrentMoney", 0);
        }

        public static void SetCurrentMoney(int amount)
        {
            int currentMoney = GetCurrentMoney();
            PlayerPrefs.SetInt("CurrentMoney", currentMoney + amount);
        }
        
        // Vehicle State
        
        public static int GetCurrentVehicleIndex()
        {
            return PlayerPrefs.GetInt("CurrentVehicleIndex", 0);
        }

        public static void SetCurrentVehicleIndex(int index)
        {
            PlayerPrefs.SetInt("CurrentVehicleIndex", index);
        }
        
        public static int GetCurrentVehicleGarageIndex()
        {
            return PlayerPrefs.GetInt("CurrentVehicleGarageIndex", 0);
        }
        
        public static void SetCurrentVehicleGarageIndex(int index)
        {
            PlayerPrefs.SetInt("CurrentVehicleGarageIndex", index);
        }

        public static int GetUnlockState(string vehicleName)
        {
            return PlayerPrefs.GetInt(vehicleName, 0);
        }

        public static void SetStateVehicleIndex(string vehicleName)
        {
            PlayerPrefs.SetInt(vehicleName, 1);
        }
    }
}