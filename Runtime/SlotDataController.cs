using System;
using System.Linq;
using LittleBit.Modules.CoreModule;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBit.Modules.Warehouse.Data;
using LittleBit.Modules.Warehouse.Data.Interfaces;
using LittleBit.Modules.Warehouse.DataOperation;
using LittleBit.Modules.Warehouse.Inerfaces;
using LittleBit.Modules.Warehouse.Operations;
using LittleBit.Modules.Warehouse.Operations.Item;
using LittleBit.Modules.Warehouse.Operations.Slot;

namespace LittleBit.Modules.Warehouse
{
    internal class SlotDataController : IDataObservable, ISlotProvider, ITrackable
    {
        public event Action<IReadOnlySlotData> SlotChange;
        public ISlotObservable SlotObservable => new SlotObservable(GetSlot(), this);
        
        private readonly SlotConfig _config;
        
        private readonly IDataProcessor<WarehouseData> _dataProcessor;
        
        public ISlotOperation Try { get; }
        public IDoSlotOperation Do { get; }
        public CanItemOperation Can { get; }

        public double Value => SlotObservable.SlotData.Value;
        public event Action<double> OnValueChange;
        

        public IKeyHolder KeyHolder => _config.ResourceConfig;
        
        public SlotDataController(SlotConfig config, IDataProcessor<WarehouseData> dataProcessor)
        {
            _config = config;
            _dataProcessor = dataProcessor;
            InitializeData();
            Try = new TryItemOperation(this);
            Do = new DoItemOperation(this);
            Can = new CanItemOperation(this);
        }
        
        private void InitializeData()
        {
            var warehouseData = _dataProcessor.GetData();
            var slot = GetSlot();

            if (slot == null || string.IsNullOrEmpty(slot.WarehouseItemData.GetKey()))
            {
                slot = new SlotData(_config);
                warehouseData.Slots.Add(slot);
                _dataProcessor.SetData(warehouseData);
            }
        }

        
        public bool SlotOperation(Func<SlotData, bool> func)
        {
            if (func == null)
                throw new Exception("func cannot be null");

            var warehouseData = _dataProcessor.GetData();
            var slot = GetSlot();

            if (slot == null)
                throw new Exception("slot not found");

            var result = func.Invoke(slot);

            if (result)
            {
                _dataProcessor.SetData(warehouseData);
                SlotChange?.Invoke(slot);
                OnValueChange?.Invoke(slot.Value);
            }
            
            return result;
        }

        public SlotData GetSlot()
        {
            var warehouseData = _dataProcessor.GetData();
            var warehouseSlots = warehouseData.Slots;
            return warehouseSlots.FirstOrDefault(s => s.GetKey() == KeyHolder.GetKey());
        }
        
    }
}