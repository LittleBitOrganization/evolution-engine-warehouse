using LittleBit.Modules.Warehouse.Data.Interfaces;
using LittleBit.Modules.Warehouse.Inerfaces;

namespace LittleBit.Modules.Warehouse
{
    internal class SlotObservable : ISlotObservable
    {
        public IReadOnlySlotData SlotData { get; }
        public IDataObservable Observable { get; }
        
        public SlotObservable(IReadOnlySlotData slotData, IDataObservable dataObservable)
        {
            SlotData = slotData;
            Observable = dataObservable;
        }
    }
}