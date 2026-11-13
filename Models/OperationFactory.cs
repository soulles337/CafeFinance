using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>
    /// Фабрика операций (паттерн «Фабричный метод»): по признаку в первом поле записи
    /// создаёт объект нужного производного класса.
    /// </summary>
    public static class OperationFactory
    {
        public static bool IsOperationTag(string tag)
        {
            return tag == "SALE" || tag == "PURCH" || tag == "EXP";
        }

        public static FinancialOperation FromRecord(string[] parts, CafeData data)
        {
            switch (parts[0])
            {
                case "SALE":
                    return new SaleOperation(parts, data);
                case "PURCH":
                    return new PurchaseOperation(parts, data);
                case "EXP":
                    return new ExpenseOperation(parts, data);
                default:
                    throw new DataFileException("Неизвестный тип операции: «" + parts[0] + "».");
            }
        }
    }
}
