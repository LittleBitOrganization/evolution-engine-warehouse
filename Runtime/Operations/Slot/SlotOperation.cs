using LittleBit.Modules.Warehouse.Inerfaces;

namespace LittleBit.Modules.Warehouse.Operations.Slot
{
    internal abstract class SlotOperation
    {
        protected readonly ISlotControllerProvider SlotControllerProvider;
        protected SlotOperation(ISlotControllerProvider controller) => SlotControllerProvider = controller;
    }
}