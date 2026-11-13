namespace CafeFinance.Models
{
    /// <summary>Объект, который можно записать в файл данных одной строкой.</summary>
    public interface IFileRecord
    {
        string ToRecord();
    }
}
