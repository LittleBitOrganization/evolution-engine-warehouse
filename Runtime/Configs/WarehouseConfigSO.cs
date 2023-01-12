using System;
using LittleBit.Modules.Description.ResourceGenerator;
using LittleBit.Modules.Warehouse.Configs;
using NaughtyAttributes;
using UnityEngine;

namespace Infrastructure.New
{
    [CreateAssetMenu(fileName = "WarehouseConfig", menuName = "Configs/Productions/WarehouseConfig", order = 0)]
    public partial class WarehouseConfigSO : ScriptableObject
    {
        [SerializeField, AllowNesting] private WarehouseConfig _config;
        [SerializeField, AllowNesting] private ResourceConfig _input;
        [SerializeField, AllowNesting] private ResourceConfig _output;


        public WarehouseConfig Config => _config;
        
        [Obsolete("Don't use! The warehouse is no longer responsible for input and output resources")]
        public ResourceConfig InputResourceConfig => _input;
        
        [Obsolete("Don't use! The warehouse is no longer responsible for input and output resources")]
        public ResourceConfig OutputResourceConfig => _output;

    }
}
