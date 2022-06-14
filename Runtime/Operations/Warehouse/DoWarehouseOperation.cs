using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Operations.Warehouse
{
    public class DoWarehouseOperation : WarehouseOperation, ISlotOperation
    {
        public DoWarehouseOperation(ISlotOperation slotOperation) : base(slotOperation) { }

        public bool Add(IResourceConfig resourceConfig, double value)
        {
            _slotOperation.Add(resourceConfig, value);
            return true;
        }

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            _slotOperation.Substract(resourceConfig, value);
            return true;
        }
    }
}