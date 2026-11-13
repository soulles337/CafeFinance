using System;
using CafeFinance.Services;

namespace CafeFinance.Models
{
    /// <summary>
    /// Абстрактная строка документа (чека или накладной): наименование, количество и цена за единицу.
    /// </summary>
    public abstract class LineItem : IFileRecord
    {
        private string name = string.Empty;
        private decimal quantity;
        private decimal unitPrice;

        protected LineItem(string name, decimal unitPrice, decimal quantity)
        {
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public string Name
        {
            get { return name; }
            set { name = Validator.RequireText(value, "Наименование позиции", 100); }
        }

        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = Validator.RequirePositive(value, "Количество"); }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = Validator.RequireNonNegative(value, "Цена"); }
        }

        /// <summary>Сумма по строке, округлённая до копеек.</summary>
        public virtual decimal GetTotal()
        {
            return Math.Round(quantity * unitPrice, 2, MidpointRounding.AwayFromZero);
        }

        public abstract string ToRecord();
    }
}
