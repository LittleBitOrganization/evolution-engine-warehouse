namespace LittleBit.Modules.Warehouse.Operations.Warehouse
{
    public abstract class WarehouseOperation
    {
        protected ISlotOperation _slotOperation;

        protected WarehouseOperation(ISlotOperation slotOperation) => _slotOperation = slotOperation;
    }
}