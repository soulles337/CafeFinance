using System;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Прочий расход кафе: аренда, коммунальные услуги, зарплата, оборудование.</summary>
    public class ExpenseOperation : FinancialOperation
    {
        private ExpenseCategory category = ExpenseCategory.Other;
        private decimal amount;

        public ExpenseOperation()
        {
        }

        public ExpenseOperation(int id, DateTime date, Employee employee, string comment,
                                ExpenseCategory category, decimal amount)
            : base(id, date, employee, comment)
        {
            this.category = category;
            Amount = amount;
        }

        public ExpenseOperation(string[] parts, CafeData data) : base(parts, data)
        {
            RecordFormat.RequireFields(parts, 7);
            category = RecordFormat.ParseEnum<ExpenseCategory>(parts[5], "Категория расхода");
            Amount = RecordFormat.ParseDecimal(parts[6], "Сумма");
        }

        public ExpenseCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = Validator.RequireRange(value, 0.01m, 1000000000m, "Сумма"); }
        }

        public override OperationKind Kind
        {
            get { return OperationKind.Expense; }
        }

        public override string TypeName
        {
            get { return "Расход"; }
        }

        protected override string RecordTag
        {
            get { return "EXP"; }
        }

        public override decimal GetAmount()
        {
            return amount;
        }

        public override string GetDescription()
        {
            return Localizer.Name(category);
        }

        public override void Validate()
        {
            if (Employee == null)
            {
                throw new ValidationException("Следует указать сотрудника, оформившего операцию.");
            }
            if (amount <= 0)
            {
                throw new ValidationException("Сумма расхода должна быть больше нуля.");
            }
        }

        protected override string[] GetSpecificFields()
        {
            return new[]
            {
                ((int)category).ToString(),
                RecordFormat.FormatDecimal(amount)
            };
        }
    }
}
