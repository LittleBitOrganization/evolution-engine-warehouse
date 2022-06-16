﻿using System;
using System.Linq;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBit.Modules.Warehouse.Data;
using LittleBit.Modules.Warehouse.Data.Interfaces;
using LittleBit.Modules.Warehouse.DataOperation;
using LittleBit.Modules.Warehouse.Inerfaces;
using LittleBit.Modules.Warehouse.Operations;
using LittleBit.Modules.Warehouse.Operations.Item;

namespace LittleBit.Modules.Warehouse
{
    internal class SlotDataController : IDataObservable, ISlotProvider
    {
        public event Action<IReadOnlySlotData> SlotChange;
        public ISlotObservable SlotObservable => new SlotObservable(GetSlot(), this);
        
        private readonly SlotConfig _config;
        private readonly IDataProcessor<InternalWarehouseData> _dataProcessor;
        
        public ISlotOperation Try { get; }
        public ISlotOperation Do { get; }
        public CanItemOperation Can { get; }
        

        public IKeyHolder KeyHolder => _config.ResourceConfig;
        
        public SlotDataController(SlotConfig config, IDataProcessor<InternalWarehouseData> dataProcessor)
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

            if (slot != null) return;
            
            slot = new InternalSlotData(new InternalWarehouseItemData(KeyHolder.GetKey()), _config.Capacity);
            warehouseData.Slots.Add(slot);
            _dataProcessor.SetData(warehouseData);
        }

        
        public bool SlotOperation(Func<InternalSlotData, bool> func)
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
            }
            
            return result;
        }

        public InternalSlotData GetSlot()
        {
            var warehouseData = _dataProcessor.GetData();
            var warehouseSlots = warehouseData.Slots;
            return warehouseSlots.FirstOrDefault(s => s.GetKey() == KeyHolder.GetKey());
        }
    }
}