using System.Collections.Generic;
using System.Linq;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Inerfaces;

namespace LittleBit.Modules.Warehouse.Operations.Slot
{
    internal class CanSlotOperation : SlotOperation, ISlotOperation
    {
        public CanSlotOperation(ISlotControllerProvider controller) : base(controller) { }

        public bool Add(IResourceConfig resourceConfig, double value) => 
            SlotControllerProvider.GetSlot(resourceConfig).Can.Add(resourceConfig, value);

        public bool AddMany(Dictionary<IResourceConfig, double> dict) =>
            dict.Select(pair => Add(pair.Key, pair.Value)).All(success => success);

        public bool Substract(IResourceConfig resourceConfig, double value) => 
            SlotControllerProvider.GetSlot(resourceConfig).Can.Substract(resourceConfig, value);
    }
}