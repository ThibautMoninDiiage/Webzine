namespace Webzine.Business.Contracts
{
    public interface IJsonService
    {
        void WriteJsonFile<T>(string filename, T param);
        T ReadJsonFile<T>(string filename);
    }
}
