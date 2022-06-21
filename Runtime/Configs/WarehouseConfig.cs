using System;
using System.Collections.Generic;
using LittleBit.Modules.Description;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBit.Modules.Warehouse.Configs
{
    [Serializable]
    public class WarehouseConfig : IKeyHolder
    {
        [SerializeField] public List<SlotConfig> SlotConfigs;
        
        [OnValueChanged(nameof(OnChangeKey))]
        [AllowNesting]
        [SerializeField] private string _key;
        
        [SerializeField, DisableIf(nameof(Boolean.TrueString)), AllowNesting]
        private string _prefixKey;

        [SerializeField, DisableIf(nameof(Boolean.TrueString)), AllowNesting]
        private string _fullKey;
        
        public string Key => GetKey();
        
        public void InitPrefixKey(string prefixKey)
        {
            _prefixKey = prefixKey;
            OnChangeKey();
        }
        
        public string GetKey()
        {
            if (_prefixKey == "")
            {
                return _key;
            }
            return _prefixKey + "/" + _key;
        }

        private void OnChangeKey()
        {
            _fullKey = GetKey();
        }

    }
}