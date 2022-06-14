using UnityEngine;

namespace LittleBit.Modules.Warehouse.DataOperation
{
    public class DataProcessorCustom<T> : IDataProcessor<T> where T : CoreModule.Data, new()
    {
        private string _key;

        public DataProcessorCustom(string key)
        {
            _key = key;
        }

        public void SetData(T data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(_key, json);
            PlayerPrefs.Save();
        }

        public T GetData()
        {
            var json = JsonUtility.ToJson(new T());
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(_key, json));
        }
    }
}