using System;
using System.Collections.Generic;
using LittleBit.Modules.Description;
using UnityEngine;

namespace LittleBit.Modules.Warehouse.Configs
{
    [Serializable]
    public class WarehouseConfig : IKeyHolder
    {
        [SerializeField] public List<SlotConfig> SlotConfigs;
        [SerializeField] private string _key;
        public string GetKey() => _key;
    }
}