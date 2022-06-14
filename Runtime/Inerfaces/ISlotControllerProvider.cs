using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Inerfaces
{
    internal interface ISlotControllerProvider
    {
        SlotDataController GetSlot(IResourceConfig resourceConfig);
    }
}