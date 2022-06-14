namespace LittleBit.Modules.Warehouse.Operations.Item
{
    public abstract class ItemOperation
    {
        internal readonly ISlotProvider _slotProvider;

        internal ItemOperation(ISlotProvider slotProvider)
        {
            _slotProvider = slotProvider;
        }
    }
}