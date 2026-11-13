namespace CafeFinance.Models
{
    /// <summary>Вид финансовой операции: приход или расход денежных средств.</summary>
    public enum OperationKind
    {
        Income,
        Expense
    }

    /// <summary>Способ оплаты чека.</summary>
    public enum PaymentMethod
    {
        Cash,
        Card
    }

    /// <summary>Категория блюда в меню кафе.</summary>
    public enum DishCategory
    {
        FirstCourse,
        MainCourse,
        Salad,
        Bakery,
        Drink,
        Other
    }

    /// <summary>Категория прочих (непроизводственных) расходов.</summary>
    public enum ExpenseCategory
    {
        Rent,
        Utilities,
        Salary,
        Equipment,
        Other
    }

    /// <summary>Должность сотрудника кафе.</summary>
    public enum EmployeePosition
    {
        Cashier,
        Cook,
        Manager,
        Accountant
    }

    /// <summary>Поле, по которому сортируется журнал операций.</summary>
    public enum SortField
    {
        Date,
        Amount,
        Type,
        Employee
    }
}
