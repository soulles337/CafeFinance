using System;
using CafeFinance.Models;

namespace CafeFinance.UI
{
    /// <summary>Подбирает диалог редактирования, соответствующий типу существующей операции.</summary>
    public static class EditorFactory
    {
        public static IOperationEditor CreateFor(CafeData data, FinancialOperation operation)
        {
            SaleOperation sale = operation as SaleOperation;
            if (sale != null)
            {
                return new SaleForm(data, sale);
            }

            PurchaseOperation purchase = operation as PurchaseOperation;
            if (purchase != null)
            {
                return new PurchaseForm(data, purchase);
            }

            ExpenseOperation expense = operation as ExpenseOperation;
            if (expense != null)
            {
                return new ExpenseForm(data, expense);
            }

            throw new ArgumentException("Для данного типа операции диалог редактирования не предусмотрен.");
        }
    }
}
