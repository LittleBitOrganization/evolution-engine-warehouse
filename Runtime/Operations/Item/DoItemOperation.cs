﻿using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Operations.Slot;

namespace LittleBit.Modules.Warehouse.Operations.Item
{
    internal class DoItemOperation : ItemOperation, IDoSlotOperation
    {
        public DoItemOperation(ISlotProvider slotProvider) : base(slotProvider) { }

        public bool Add(IResourceConfig resourceConfig, double value)
        {
            _slotProvider.SlotOperation(slot =>
            {
                slot.Value += value;
                return true;
            });
            return true;
        }

        public bool AddMany(Dictionary<IResourceConfig, double> dict) =>
            dict.Select(pair => Add(pair.Key, pair.Value)).All(success => success);

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            _slotProvider.SlotOperation(slot =>
            {
                slot.Value -= value;
                return true;
            });
            return true;
        }

        public bool SetCapacity(IResourceConfig resourceConfig, double value)
        {
            _slotProvider.SlotOperation(slot =>
            {
                slot.SetCapacity(value);
                return true;
            });
            return true;
        }
    }
}