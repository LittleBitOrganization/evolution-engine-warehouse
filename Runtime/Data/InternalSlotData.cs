using System;
using LittleBit.Modules.Warehouse.Configs;
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

        private SlotConfig _config;

        public double Value
        {
            get => WarehouseItemData.GetValue();
            set => warehouseItemData.Value = value;
        }
        
        public SlotData(SlotConfig config)
        {
            _config = config;
            
            warehouseItemData = new WarehouseItemData(_config.ResourceConfig.GetKey());
            _capacity = _config.Capacity;
        }

        public string GetKey() => 
            WarehouseItemData.GetKey();   
        
        public void RefreshFromScriptable()
        {
            _capacity = _config.Capacity;
            warehouseItemData = new WarehouseItemData(_config.ResourceConfig.GetKey());
        }

        public void SetCapacity(double capacity)
        {
            _capacity = capacity;
        }
    }    
}