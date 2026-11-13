using System;
using System.Collections.Generic;
using CafeFinance.Models;

namespace CafeFinance.Services
{
    /// <summary>
    /// Сортировка операций. Правило сравнения выбирается по полю сортировки
    /// и передаётся в метод List.Sort в виде делегата Comparison.
    /// </summary>
    public static class OperationSorter
    {
        public static List<FinancialOperation> Sort(IEnumerable<FinancialOperation> source,
                                                    SortField field, bool descending)
        {
            List<FinancialOperation> list = new List<FinancialOperation>(source);
            Comparison<FinancialOperation> comparison = GetComparison(field);
            list.Sort((a, b) =>
            {
                int result = comparison(a, b);
                if (result == 0)
                {
                    result = a.Id.CompareTo(b.Id);
                }
                return descending ? -result : result;
            });
            return list;
        }

        private static Comparison<FinancialOperation> GetComparison(SortField field)
        {
            switch (field)
            {
                case SortField.Date:
                    return (a, b) => a.Date.CompareTo(b.Date);
                case SortField.Amount:
                    return (a, b) => a.GetAmount().CompareTo(b.GetAmount());
                case SortField.Type:
                    return (a, b) => string.Compare(a.TypeName, b.TypeName, StringComparison.CurrentCulture);
                case SortField.Employee:
                    return (a, b) => string.Compare(a.Employee.Name, b.Employee.Name, StringComparison.CurrentCulture);
                default:
                    throw new ArgumentOutOfRangeException(nameof(field));
            }
        }
    }
}
