using System;
using LittleBit.Modules.Warehouse.Data;
using LittleBit.Modules.Warehouse.Operations.Item;

namespace LittleBit.Modules.Warehouse
{
    internal interface ISlotProvider
    {
        public InternalSlotData GetSlot();
        public bool SlotOperation(Func<InternalSlotData, bool> func);
        public CanItemOperation Can { get; }
    }
}