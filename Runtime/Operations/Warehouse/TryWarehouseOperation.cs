﻿using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Operations.Warehouse
{
    public class TryWarehouseOperation : WarehouseOperation, ISlotOperation
    {
        public TryWarehouseOperation(ISlotOperation slotOperation) : base(slotOperation) { }

        public bool Add(IResourceConfig resourceConfig, double value) =>
            _slotOperation.Add(resourceConfig, value);

        public bool Substract(IResourceConfig resourceConfig, double value) =>
            _slotOperation.Substract(resourceConfig, value);

    }
}