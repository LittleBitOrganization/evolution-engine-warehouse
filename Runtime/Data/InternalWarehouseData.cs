using System;
using System.Collections.Generic;
using LittleBit.Modules.Warehouse.Inerfaces;

namespace LittleBit.Modules.Warehouse.Data
{
    [Serializable]
    public class WarehouseData : CoreModule.Data
    {
        public List<SlotData> Slots;
        public WarehouseData() => Slots = new List<SlotData>();

    }
}