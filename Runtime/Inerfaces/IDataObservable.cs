using System;
using LittleBit.Modules.Warehouse.Data.Interfaces;

namespace LittleBit.Modules.Warehouse.Inerfaces
{
    public interface IDataObservable
    {
        event Action<IReadOnlySlotData> SlotChange;
    }
}