# Inporting
``` json
"com.littlebitgames.warehouse": "https://github.com/LittleBitOrganization/evolution-engine-warehouse.git"
```

# Dependencies:
``` json
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm",
"com.littlebitgames.descriptioncomponentsmodule": "https://github.com/LittleBitOrganization/evolution-engine-description-components.git",
"com.littlebitgames.coremodule": "https://github.com/LittleBitOrganization/evolution-engine-core.git"
```

# Installation

- ICreator - 
- WarehouseConfig - 

```c#
    [SerializeField] private ScriptableObject _warehouseData;

    public override void InstallBindings()
    {
        Container.Bind<ICreator>()
                 .To<Creator>()
                 .AsSingle()
                 .NonLazy();

        Container.Bind<WarehouseConfig>().FromScriptableObject(_warehouseData)
                 .AsSingle()
                 .NonLazy();
    }
```
