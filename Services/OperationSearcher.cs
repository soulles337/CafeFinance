using System;
using System.Collections.Generic;
using CafeFinance.Models;

namespace CafeFinance.Services
{
    /// <summary>
    /// Поиск операций по нескольким параметрам: тексту, виду операции,
    /// периоду дат и диапазону сумм.
    /// </summary>
    public static class OperationSearcher
    {
        public static List<FinancialOperation> Find(IEnumerable<FinancialOperation> source, SearchCriteria criteria)
        {
            List<FinancialOperation> result = new List<FinancialOperation>();
            foreach (FinancialOperation operation in source)
            {
                if (Matches(operation, criteria))
                {
                    result.Add(operation);
                }
            }
            return result;
        }

        /// <summary>Проверяет операцию на соответствие всем заданным параметрам отбора.</summary>
        public static bool Matches(FinancialOperation operation, SearchCriteria criteria)
        {
            if (criteria.Kind.HasValue && operation.Kind != criteria.Kind.Value)
            {
                return false;
            }
            if (criteria.DateFrom.HasValue && operation.Date.Date < criteria.DateFrom.Value.Date)
            {
                return false;
            }
            if (criteria.DateTo.HasValue && operation.Date.Date > criteria.DateTo.Value.Date)
            {
                return false;
            }

            decimal amount = operation.GetAmount();
            if (criteria.AmountFrom.HasValue && amount < criteria.AmountFrom.Value)
            {
                return false;
            }
            if (criteria.AmountTo.HasValue && amount > criteria.AmountTo.Value)
            {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(criteria.Text) && !ContainsText(operation, criteria.Text))
            {
                return false;
            }
            return true;
        }

        private static bool ContainsText(FinancialOperation operation, string text)
        {
            string part = text.Trim();
            return Contains(operation.TypeName, part)
                || Contains(operation.Employee.Name, part)
                || Contains(operation.Comment, part)
                || Contains(operation.GetDescription(), part);
        }

        private static bool Contains(string source, string part)
        {
            return source.IndexOf(part, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
