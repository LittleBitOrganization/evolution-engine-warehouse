namespace LittleBit.Modules.Warehouse.DataOperation
{
    public interface IDataProcessor<T> where T : CoreModule.Data, new()
    {
        void SetData(T data);
        T GetData();
    }
}