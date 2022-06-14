using System;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Warehouse.Data.Interfaces;

namespace LittleBit.Modules.Warehouse.Data
{
    [Serializable]
    internal class InternalWarehouseItemData : Resource, IReadOnlyWarehouseItemData
    {
        public InternalWarehouseItemData(string key) : base(key) { }
        
        public string GetKey() => Id;
        public double GetValue() => Value;
    }
}