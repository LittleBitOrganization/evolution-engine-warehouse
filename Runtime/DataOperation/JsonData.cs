using System;

namespace LittleBit.Modules.Warehouse.DataOperation
{
    [Serializable]
    public class JsonData : CoreModule.Data
    {
        public string Data;

        public JsonData(string data) => Data = data;

        public JsonData(){}
    }
}