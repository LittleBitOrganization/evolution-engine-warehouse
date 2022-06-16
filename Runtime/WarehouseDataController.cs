using System;
using System.Collections.Generic;
using LittleBit.Modules.Description;
using LittleBit.Modules.Warehouse.Configs;
using LittleBit.Modules.Warehouse.Data;
using LittleBit.Modules.Warehouse.DataOperation;
using LittleBit.Modules.Warehouse.Inerfaces;
using LittleBit.Modules.Warehouse.Operations;
using LittleBit.Modules.Warehouse.Operations.Slot;
using UnityEngine;

namespace LittleBit.Modules.Warehouse
{
    internal class WarehouseDataController : ISerializable, ISlotControllerProvider
    {
        public ISlotObservable this[IResourceConfig index] => _slotDataControllers[index].SlotObservable;
        
        public ISlotOperation Try { get; }
        public ISlotOperation Do { get; }
        public ISlotOperation Can { get; }
        
        private readonly WarehouseConfig _config;
        private Dictionary<IResourceConfig, SlotDataController> _slotDataControllers;
        private IDataProcessor<InternalWarehouseData> _dataProcessor;

        public WarehouseDataController(DataProcessorsFactory<InternalWarehouseData> dataProcessorsFactory, WarehouseConfig config)
        {
            _config = config;
            _dataProcessor = dataProcessorsFactory.Create<DataProcessorCustom<InternalWarehouseData>>(_config.GetKey());
            _slotDataControllers = new Dictionary<IResourceConfig, SlotDataController>();
            
            Try = new TrySlotOperation(this);
            Do = new DoSlotOperation(this);
            Can = new CanSlotOperation(this);
        }

        public string Serialize() =>
            JsonUtility.ToJson(_dataProcessor.GetData());

        public WarehouseDataController InitializeData()
        {
            var warehouseData = _dataProcessor.GetData();
            InitializeSlots();
            _dataProcessor.SetData(warehouseData);
            return this;
        }
        
        private void InitializeSlots()
        {
            foreach (var slotConfig in _config.SlotConfigs)
            {
                var slotDataController = new SlotDataController(slotConfig, _dataProcessor);

                if (_slotDataControllers.ContainsKey(slotConfig.ResourceConfig))
                    throw new Exception($"Key {slotConfig.ResourceConfig.GetKey()} already exist");
                
                _slotDataControllers.Add(slotConfig.ResourceConfig, slotDataController);
            }
        }

        public SlotDataController GetSlot(IResourceConfig resourceConfig)
        {
            if (_slotDataControllers.ContainsKey(resourceConfig))
            {
                return _slotDataControllers[resourceConfig];
            }

            throw new KeyNotFoundException($"{resourceConfig.GetKey()}");
        }
    }
}















