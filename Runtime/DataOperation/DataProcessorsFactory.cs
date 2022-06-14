namespace LittleBit.Modules.Warehouse.DataOperation
{
    public class DataProcessorsFactory<TData> where TData : CoreModule.Data, new()
    {
        private readonly ICreator _creator;

        public DataProcessorsFactory(ICreator creator)
        {
            _creator = creator;
        }
        
        public TType Create<TType>(string key) where TType : IDataProcessor<TData>
        {
            return _creator.Instantiate<TType>(key);
        }
    }
}