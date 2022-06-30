using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Inerfaces;

namespace LittleBit.Modules.Warehouse.Operations.Slot
{
    internal class TrySlotOperation : SlotOperation, ISlotOperation
    {
        public TrySlotOperation(ISlotControllerProvider controller) : base(controller)
        {
        }

        public bool Add(IResourceConfig resourceConfig, double value) =>
            SlotControllerProvider.GetSlot(resourceConfig).Try.Add(resourceConfig, value);

        public bool AddMany(Dictionary<IResourceConfig, double> dict)
            => dict.Select(pair => Add(pair.Key, pair.Value)).All(success => success);

        public bool Substract(IResourceConfig resourceConfig, double value) =>
            SlotControllerProvider.GetSlot(resourceConfig).Try.Substract(resourceConfig, value);
    }
}