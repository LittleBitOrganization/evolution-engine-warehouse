using LittleBit.Modules.CoreModule;

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
            _dataStorageService.SetData(_key, data);
        }
        
        public T GetData()
        {
            return _dataStorageService.GetData<T>(_key);
        }
    }
}