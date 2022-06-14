using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Operations
{
    public interface ISlotOperation
    {
        bool Add(IResourceConfig resourceConfig, double value);
        bool Substract(IResourceConfig resourceConfig, double value);
    }
}