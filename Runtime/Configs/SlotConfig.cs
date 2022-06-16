using System;
using LittleBit.Modules.Description;
using UnityEngine;

namespace LittleBit.Modules.Warehouse.Configs
{
    [Serializable]
    public class SlotConfig
    {
        [SerializeField] private ResourceConfigInterfaceContainer _resource;
        [SerializeField] private double _capacity;
        public IResourceConfig ResourceConfig => _resource.Result;
        public double Capacity => _capacity;
    }
}