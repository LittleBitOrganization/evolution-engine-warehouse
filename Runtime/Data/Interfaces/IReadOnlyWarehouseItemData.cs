using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Data.Interfaces
{
    public interface IReadOnlyWarehouseItemData : IKeyHolder
    {
        double GetValue();
    }
}