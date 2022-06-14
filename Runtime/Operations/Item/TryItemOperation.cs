﻿using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Operations.Item
{
    public class TryItemOperation : ItemOperation, ISlotOperation
    {
        internal TryItemOperation(ISlotProvider slotProvider) : base(slotProvider) { }

        public bool Add(IResourceConfig resourceConfig, double value)
        {
            return _slotProvider.SlotOperation(slot =>
            {
                if (_slotProvider.Can.Add(resourceConfig, value) == false) 
                    return false;
                slot.Value += value;
                return true;
            });
        }

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            return _slotProvider.SlotOperation(slot =>
            {
                if (_slotProvider.Can.Substract(resourceConfig, value) == false) 
                    return false;
                slot.Value -= value;
                return true;
            });
        }
    }
}