using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Data.Interfaces
{
    public interface IReadOnlySlotData : IKeyHolder
    {
        bool Full { get; }
        double Value { get; }
        double Capacity { get; }
        double EmptySpace { get; }
        IReadOnlyWarehouseItemData  WarehouseItemData { get; }
        void RefreshFromScriptable();
        void SetCapacity(double capacity);
    }
}