using System;
using LittleBit.Modules.Warehouse.Data.Interfaces;

namespace LittleBit.Modules.Warehouse.Data
{
    [Serializable]
    internal class InternalSlotData : CoreModule.Data, IReadOnlySlotData
    {
        public IReadOnlyWarehouseItemData WarehouseItemData => _internalWarehouseItemDataData;
        public double EmptySpace => _capacity - Value;
        public double Capacity => _capacity;
        public bool Full => EmptySpace < 0.00001d;

        public InternalWarehouseItemData _internalWarehouseItemDataData;
        public double _capacity;
        
        public double Value
        {
            get => WarehouseItemData.GetValue();
            set => _internalWarehouseItemDataData.Value = value;
        }
        
        public InternalSlotData(InternalWarehouseItemData internalWarehouseItemDataData, double capacity)
        {
            _internalWarehouseItemDataData = internalWarehouseItemDataData;
            _capacity = capacity;
        }

        public string GetKey() => WarehouseItemData.GetKey();
    }
}