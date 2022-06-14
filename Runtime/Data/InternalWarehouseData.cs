using System;
using System.Collections.Generic;

namespace LittleBit.Modules.Warehouse.Data
{
    [Serializable]
    internal class InternalWarehouseData : CoreModule.Data
    {
        public List<InternalSlotData> Slots;
        public InternalWarehouseData() => Slots = new List<InternalSlotData>();
    }
}