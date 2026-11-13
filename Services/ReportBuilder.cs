using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CafeFinance.Models;

namespace CafeFinance.Services
{
    /// <summary>Формирует текстовый финансовый отчёт за период и сохраняет его в файл.</summary>
    public static class ReportBuilder
    {
        public static string Build(List<FinancialOperation> operations, DateTime from, DateTime to)
        {
            StringBuilder sb = new StringBuilder();
            AppendHeader(sb, operations, from, to);
            AppendIncome(sb, operations);
            AppendExpenses(sb, operations);
            AppendIndicators(sb, operations);
            return sb.ToString();
        }

        public static void SaveToFile(string path, string text)
        {
            try
            {
                File.WriteAllText(path, text, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                throw new DataFileException("Не удалось сохранить отчёт: " + ex.Message, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new DataFileException("Нет доступа к файлу отчёта: " + ex.Message, ex);
            }
        }

        private static void AppendHeader(StringBuilder sb, List<FinancialOperation> operations, DateTime from, DateTime to)
        {
            sb.AppendLine("ФИНАНСОВЫЙ ОТЧЁТ КАФЕ ПОЛЕСГУ");
            sb.AppendLine($"Период: {from:dd.MM.yyyy} – {to:dd.MM.yyyy}");
            sb.AppendLine($"Операций за период: {operations.Count}");
            sb.AppendLine($"  из них продаж (чеков): {FinancialCalculator.CountSales(operations)}");
            sb.AppendLine(new string('-', 60));
        }

        private static void AppendIncome(StringBuilder sb, List<FinancialOperation> operations)
        {
            sb.AppendLine($"Выручка:                          {Money(FinancialCalculator.TotalIncome(operations))}");
            Dictionary<PaymentMethod, decimal> byPayment = FinancialCalculator.IncomeByPayment(operations);
            foreach (KeyValuePair<PaymentMethod, decimal> pair in byPayment)
            {
                sb.AppendLine($"  {Localizer.Name(pair.Key),-30}  {Money(pair.Value)}");
            }
        }

        private static void AppendExpenses(StringBuilder sb, List<FinancialOperation> operations)
        {
            sb.AppendLine($"Расходы всего:                    {Money(FinancialCalculator.TotalExpense(operations))}");
            string purchasesTitle = "Закупка продуктов";
            sb.AppendLine($"  {purchasesTitle,-30}  {Money(FinancialCalculator.TotalPurchases(operations))}");
            Dictionary<ExpenseCategory, decimal> byCategory = FinancialCalculator.ExpensesByCategory(operations);
            foreach (KeyValuePair<ExpenseCategory, decimal> pair in byCategory)
            {
                sb.AppendLine($"  {Localizer.Name(pair.Key),-30}  {Money(pair.Value)}");
            }
        }

        private static void AppendIndicators(StringBuilder sb, List<FinancialOperation> operations)
        {
            sb.AppendLine(new string('-', 60));
            sb.AppendLine($"Прибыль (доходы − расходы):       {Money(FinancialCalculator.Profit(operations))}");
            sb.AppendLine($"Рентабельность продаж:            {FinancialCalculator.Profitability(operations):N2} %");
            sb.AppendLine($"Средний чек:                      {Money(FinancialCalculator.AverageCheck(operations))}");
            sb.AppendLine($"Себестоимость продаж:             {Money(FinancialCalculator.CostOfGoodsSold(operations))}");
            sb.AppendLine($"Валовая маржа:                    {FinancialCalculator.GrossMarginPercent(operations):N2} %");
            sb.AppendLine($"Постоянные расходы:               {Money(FinancialCalculator.FixedExpenses(operations))}");

            decimal? breakEven = FinancialCalculator.BreakEvenRevenue(operations);
            string text = breakEven.HasValue ? Money(breakEven.Value) : "не определена";
            sb.AppendLine($"Точка безубыточности (выручка):   {text}");
        }

        private static string Money(decimal value)
        {
            return value.ToString("N2") + " руб.";
        }
    }
}
