using System.Collections.Generic;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Operations.Slot;

namespace LittleBit.Modules.Warehouse.Operations.Warehouse
{
    public class DoWarehouseOperation : WarehouseOperation, IDoSlotOperation
    {
        private readonly IDoSlotOperation _doSlotOperation;
        public DoWarehouseOperation(IDoSlotOperation slotOperation) : base(slotOperation)
        {
            _slotOperation = slotOperation;
        }

        public bool Add(IResourceConfig resourceConfig, double value)
        {
            _slotOperation.Add(resourceConfig, value);
            return true;
        }

        public bool AddMany(Dictionary<IResourceConfig, double> dict)
            => _slotOperation.AddMany(dict);

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            _slotOperation.Substract(resourceConfig, value);
            return true;
        }

        public bool SetCapacity(IResourceConfig resourceConfig, double value)
        {
            _doSlotOperation.SetCapacity(resourceConfig, value);
            return true;
        }
    }
}