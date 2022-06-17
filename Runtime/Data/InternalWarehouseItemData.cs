using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Warehouse.Data.Interfaces;

namespace LittleBit.Modules.Warehouse.Data
{
    [Serializable]
    public class WarehouseItemData : Resource, IReadOnlyWarehouseItemData
    {
        public WarehouseItemData(string key) : base(key) { }
        
        public string GetKey() => Id;
        public double GetValue() => Value;
    }
}