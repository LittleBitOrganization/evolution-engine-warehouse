using System;
using LittleBit.Modules.Warehouse.Data.Interfaces;

namespace LittleBit.Modules.Warehouse.Data
{
    [Serializable]
    public class SlotData : CoreModule.Data, IReadOnlySlotData
    {
        public IReadOnlyWarehouseItemData WarehouseItemData => warehouseItemDataData;
        public double EmptySpace => _capacity - Value;
        public double Capacity => _capacity;
        public bool Full => EmptySpace < 0.00001d;

        public WarehouseItemData warehouseItemDataData;
        public double _capacity;
        
        public double Value
        {
            get => WarehouseItemData.GetValue();
            set => warehouseItemDataData.Value = value;
        }
        
        public SlotData(WarehouseItemData warehouseItemDataData, double capacity)
        {
            this.warehouseItemDataData = warehouseItemDataData;
            _capacity = capacity;
        }

        public string GetKey() => WarehouseItemData.GetKey();
    }
}