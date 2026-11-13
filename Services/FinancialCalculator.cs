using System;
using System.Collections.Generic;
using CafeFinance.Models;

namespace CafeFinance.Services
{
    /// <summary>
    /// Расчёт финансовых показателей по набору операций. Класс не хранит данных:
    /// обрабатываемая коллекция передаётся в методы в качестве параметра.
    /// </summary>
    public static class FinancialCalculator
    {
        /// <summary>Выручка: сумма всех доходных операций.</summary>
        public static decimal TotalIncome(IEnumerable<FinancialOperation> operations)
        {
            decimal sum = 0;
            foreach (FinancialOperation operation in operations)
            {
                if (operation.Kind == OperationKind.Income)
                {
                    sum += operation.GetAmount();
                }
            }
            return sum;
        }

        /// <summary>Расходы: сумма всех расходных операций (закупки и прочие расходы).</summary>
        public static decimal TotalExpense(IEnumerable<FinancialOperation> operations)
        {
            decimal sum = 0;
            foreach (FinancialOperation operation in operations)
            {
                if (operation.Kind == OperationKind.Expense)
                {
                    sum += operation.GetAmount();
                }
            }
            return sum;
        }

        /// <summary>Прибыль (кассовый метод): доходы минус расходы.</summary>
        public static decimal Profit(IEnumerable<FinancialOperation> operations)
        {
            return TotalIncome(operations) - TotalExpense(operations);
        }

        /// <summary>Рентабельность продаж, %: прибыль / выручка × 100.</summary>
        public static decimal Profitability(IEnumerable<FinancialOperation> operations)
        {
            decimal income = TotalIncome(operations);
            if (income == 0)
            {
                return 0;
            }
            return Math.Round(Profit(operations) / income * 100, 2);
        }

        public static int CountSales(IEnumerable<FinancialOperation> operations)
        {
            int count = 0;
            foreach (FinancialOperation operation in operations)
            {
                if (operation is SaleOperation)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>Средний чек: выручка от продаж, делённая на число чеков.</summary>
        public static decimal AverageCheck(IEnumerable<FinancialOperation> operations)
        {
            int count = CountSales(operations);
            if (count == 0)
            {
                return 0;
            }
            return Math.Round(TotalIncome(operations) / count, 2);
        }

        /// <summary>Себестоимость реализованной продукции по всем чекам.</summary>
        public static decimal CostOfGoodsSold(IEnumerable<FinancialOperation> operations)
        {
            decimal sum = 0;
            foreach (FinancialOperation operation in operations)
            {
                SaleOperation sale = operation as SaleOperation;
                if (sale != null)
                {
                    sum += sale.GetCostOfGoods();
                }
            }
            return sum;
        }

        /// <summary>Валовая маржа, %: (выручка − себестоимость) / выручка × 100.</summary>
        public static decimal GrossMarginPercent(IEnumerable<FinancialOperation> operations)
        {
            decimal income = TotalIncome(operations);
            if (income == 0)
            {
                return 0;
            }
            return Math.Round((income - CostOfGoodsSold(operations)) / income * 100, 2);
        }

        /// <summary>Постоянные расходы: сумма операций типа «Расход» (аренда, зарплата и др.).</summary>
        public static decimal FixedExpenses(IEnumerable<FinancialOperation> operations)
        {
            decimal sum = 0;
            foreach (FinancialOperation operation in operations)
            {
                if (operation is ExpenseOperation)
                {
                    sum += operation.GetAmount();
                }
            }
            return sum;
        }

        /// <summary>Сумма закупок продуктов у поставщиков.</summary>
        public static decimal TotalPurchases(IEnumerable<FinancialOperation> operations)
        {
            decimal sum = 0;
            foreach (FinancialOperation operation in operations)
            {
                if (operation is PurchaseOperation)
                {
                    sum += operation.GetAmount();
                }
            }
            return sum;
        }

        /// <summary>
        /// Точка безубыточности (выручка, при которой прибыль равна нулю):
        /// постоянные расходы / коэффициент маржинального дохода. Если расчёт невозможен — null.
        /// </summary>
        public static decimal? BreakEvenRevenue(IEnumerable<FinancialOperation> operations)
        {
            decimal income = TotalIncome(operations);
            if (income == 0)
            {
                return null;
            }
            decimal ratio = (income - CostOfGoodsSold(operations)) / income;
            if (ratio <= 0)
            {
                return null;
            }
            return Math.Round(FixedExpenses(operations) / ratio, 2);
        }

        public static Dictionary<ExpenseCategory, decimal> ExpensesByCategory(IEnumerable<FinancialOperation> operations)
        {
            Dictionary<ExpenseCategory, decimal> result = new Dictionary<ExpenseCategory, decimal>();
            foreach (FinancialOperation operation in operations)
            {
                ExpenseOperation expense = operation as ExpenseOperation;
                if (expense == null)
                {
                    continue;
                }
                decimal current;
                result.TryGetValue(expense.Category, out current);
                result[expense.Category] = current + expense.GetAmount();
            }
            return result;
        }

        public static Dictionary<PaymentMethod, decimal> IncomeByPayment(IEnumerable<FinancialOperation> operations)
        {
            Dictionary<PaymentMethod, decimal> result = new Dictionary<PaymentMethod, decimal>();
            foreach (FinancialOperation operation in operations)
            {
                SaleOperation sale = operation as SaleOperation;
                if (sale == null)
                {
                    continue;
                }
                decimal current;
                result.TryGetValue(sale.Payment, out current);
                result[sale.Payment] = current + sale.GetAmount();
            }
            return result;
        }
    }
}
