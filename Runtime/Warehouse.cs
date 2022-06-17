using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBit.Modules.Warehouse.Data;
using LittleBit.Modules.Warehouse.DataOperation;
using LittleBit.Modules.Warehouse.Inerfaces;
using LittleBit.Modules.Warehouse.Operations;
using LittleBit.Modules.Warehouse.Operations.Warehouse;

namespace LittleBit.Modules.Warehouse
{
    public class Warehouse
    {
        public ISlotObservable this[IResourceConfig index] => _warehouseDataController[index];
        
        public ISlotOperation Try { get; }
        public ISlotOperation Do { get; }
        public ISlotOperation Can { get; }

        private readonly WarehouseDataController _warehouseDataController;
        
        public Warehouse(ICreator creator, WarehouseConfig config)
        {
            var factory = new DataProcessorsFactory<WarehouseData>(creator);
            _warehouseDataController = new WarehouseDataController(factory, config).InitializeData();
            Try = new TryWarehouseOperation(_warehouseDataController.Try);
            Do = new DoWarehouseOperation(_warehouseDataController.Do);
            Can = new CanWarehouseOperation(_warehouseDataController.Can);
        }
    }
}