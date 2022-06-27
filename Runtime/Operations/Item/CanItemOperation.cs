using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.Description;

namespace LittleBit.Modules.Warehouse.Operations.Item
{
    internal class CanItemOperation : ItemOperation, ISlotOperation
    {
        public CanItemOperation(ISlotProvider slotProvider) : base(slotProvider)
        {
        }

        public bool Add(IResourceConfig resourceConfig, double value)
        {
            var slot = _slotProvider.GetSlot();
            if (slot == null) return false;
            return slot.Value + value <= slot.Capacity;
        }

        public bool AddMany(Dictionary<IResourceConfig, double> dict)
            => dict.Select(pair => Add(pair.Key, pair.Value)).All(success => success);

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            var slot = _slotProvider.GetSlot();
            if (slot == null) return false;
            return slot.Value - value >= 0;
        }
    }
}