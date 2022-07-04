using System;
using LittleBit.Modules.Description;
using LittleBit.Modules.Description.ResourceGenerator;
using UnityEngine;

namespace LittleBit.Modules.Warehouse.Configs
{
    [Serializable]
    public class SlotConfig
    {
        [SerializeField] private ResourceConfig _resource;
        [SerializeField] private double _capacity;


        public SlotConfig(ResourceConfig resourceConfig, double capacity)
        {
            _resource = resourceConfig;
            _capacity = capacity;
        }
        public IResourceConfig ResourceConfig => _resource;
        public double Capacity => _capacity;
        
        
        
        
    }
}