using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Inerfaces;

namespace LittleBit.Modules.Warehouse.Operations.Slot
{
    public interface IDoSlotOperation : ISlotOperation
    {
        bool SetCapacity(IResourceConfig resourceConfig, double value);
    }
    internal class DoSlotOperation : SlotOperation, IDoSlotOperation
    {
        public DoSlotOperation(ISlotControllerProvider controller) : base(controller)
        {
        }

        public bool Add(IResourceConfig resourceConfig, double value)
        {
            SlotControllerProvider.GetSlot(resourceConfig).Do.Add(resourceConfig, value);
            return true;
        }

        public bool AddMany(Dictionary<IResourceConfig, double> dict) =>
            dict.Select(pair => Add(pair.Key, pair.Value)).All(success => success);

        public bool Substract(IResourceConfig resourceConfig, double value)
        {
            SlotControllerProvider.GetSlot(resourceConfig).Do.Substract(resourceConfig, value);
            return true;
        }

        public bool SetCapacity(IResourceConfig resourceConfig, double value)
        {
            SlotControllerProvider.GetSlot(resourceConfig).Do.SetCapacity(resourceConfig, value);
            return true;
        }
    }
}