using LittleBit.Modules.CoreModule;
using UnityEngine;

namespace LittleBit.Modules.Warehouse.DataOperation
{
    public class DataProcessor<T> : IDataProcessor<T> where T : CoreModule.Data, new()
    {
        private readonly IDataStorageService _dataStorageService;
        private readonly string _key;

        public DataProcessor(IDataStorageService dataStorageService, string key)
        {
            _dataStorageService = dataStorageService;
            _key = key;
        }

        public void SetData(T data)
        {
            var serialize = Serialize(data);
            var jsonData = new JsonData(serialize);
            
            _dataStorageService.SetData(_key, jsonData);
        }
        
        public T GetData()
        {
            var jsonData = _dataStorageService.GetData<JsonData>(_key);
            return Deserialize(jsonData.Data);
        }

        private string Serialize(T data) => JsonUtility.ToJson(data);

        private T Deserialize(string json) => JsonUtility.FromJson<T>(json);
    }
}