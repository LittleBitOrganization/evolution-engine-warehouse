using System;
using LittleBit.Modules.Description;
using LittleBit.Modules.Description.ResourceGenerator;
using NaughtyAttributes;
using UnityEngine;

namespace LittleBit.Modules.Warehouse.Configs
{
    [Serializable]
    public class SlotConfig
    {
        [SerializeField] private ResourceConfig _resource;
        [SerializeField] private bool isInfinity = false;
        [SerializeField, HideIf(nameof(IsInfinity))] private double _capacity;

        public bool IsInfinity => isInfinity;

        public SlotConfig(ResourceConfig resourceConfig, double capacity)
        {
            _resource = resourceConfig;
            _capacity = capacity;
        }
        public IResourceConfig ResourceConfig => _resource;
        public double Capacity => isInfinity? Double.MaxValue : _capacity;
        
        
        
        
    }
}