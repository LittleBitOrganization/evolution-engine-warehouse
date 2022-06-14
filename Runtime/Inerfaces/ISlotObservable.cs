using LittleBit.Modules.Warehouse.Data.Interfaces;

namespace LittleBit.Modules.Warehouse.Inerfaces
{
    public interface ISlotObservable
    {
        IReadOnlySlotData SlotData { get; }
        IDataObservable Observable { get; }
    }
}