using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Operations.Item
{
    internal class DoItemOperation : ItemOperation, ISlotOperation
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

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            var slot = _slotProvider.GetSlot();
            if (slot == null) return false;
            return slot.Value - value >= 0;
        }
    }
}