using System;
using LittleBit.Modules.Warehouse.Data;
using LittleBit.Modules.Warehouse.Operations.Item;

namespace LittleBit.Modules.Warehouse
{
    internal interface ISlotProvider
    {
        public SlotData GetSlot();
        public bool SlotOperation(Func<SlotData, bool> func);
        public CanItemOperation Can { get; }
    }
}