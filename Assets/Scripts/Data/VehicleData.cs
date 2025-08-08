using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class VehicleData : ScriptableObject
    {
        private static VehicleData _instance;

        public static VehicleData Instance
        {
            get
            {
                if(_instance == null)
                    _instance = Resources.Load<VehicleData>("Vehicle Data");

                return _instance;
            }
        }
        public Vehicle[] vehicles;

        [System.Serializable]
        public class Vehicle
        {
            public bool isUnlocked;
            public string name;
            public Sprite icon;
            public int price;
        }
    }
}