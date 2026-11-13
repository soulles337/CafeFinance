using System;
using System.Collections.Generic;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Продажа (кассовый чек): источник выручки кафе.</summary>
    public class SaleOperation : FinancialOperation
    {
        private readonly List<OrderLine> lines = new List<OrderLine>();
        private PaymentMethod payment = PaymentMethod.Cash;
        private decimal discountPercent;

        public SaleOperation()
        {
        }

        public SaleOperation(int id, DateTime date, Employee employee, string comment,
                             PaymentMethod payment, decimal discountPercent)
            : base(id, date, employee, comment)
        {
            this.payment = payment;
            DiscountPercent = discountPercent;
        }

        public SaleOperation(string[] parts, CafeData data) : base(parts, data)
        {
            RecordFormat.RequireFields(parts, 8);
            payment = RecordFormat.ParseEnum<PaymentMethod>(parts[5], "Способ оплаты");
            DiscountPercent = RecordFormat.ParseDecimal(parts[6], "Скидка");
            foreach (string item in parts[7].Split(RecordFormat.ItemSeparator))
            {
                if (item.Length > 0)
                {
                    lines.Add(OrderLine.FromRecord(item));
                }
            }
        }

        public PaymentMethod Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        public decimal DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = Validator.RequireRange(value, 0, 100, "Скидка, %"); }
        }

        public IReadOnlyList<OrderLine> Lines
        {
            get { return lines; }
        }

        public override OperationKind Kind
        {
            get { return OperationKind.Income; }
        }

        public override string TypeName
        {
            get { return "Продажа"; }
        }

        protected override string RecordTag
        {
            get { return "SALE"; }
        }

        /// <summary>Добавляет позицию; одинаковые блюда с той же ценой объединяются.</summary>
        public void AddLine(OrderLine line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }
            foreach (OrderLine existing in lines)
            {
                if (existing.Name == line.Name && existing.UnitPrice == line.UnitPrice)
                {
                    existing.Quantity += line.Quantity;
                    return;
                }
            }
            lines.Add(line);
        }

        public bool RemoveLine(OrderLine line)
        {
            return lines.Remove(line);
        }

        /// <summary>Сумма чека до применения скидки.</summary>
        public decimal GetSubtotal()
        {
            decimal sum = 0;
            foreach (OrderLine line in lines)
            {
                sum += line.GetTotal();
            }
            return sum;
        }

        /// <summary>Итоговая сумма чека с учётом скидки.</summary>
        public override decimal GetAmount()
        {
            decimal total = GetSubtotal() * (100 - discountPercent) / 100;
            return Math.Round(total, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>Себестоимость проданных позиций.</summary>
        public decimal GetCostOfGoods()
        {
            decimal sum = 0;
            foreach (OrderLine line in lines)
            {
                sum += line.GetCostTotal();
            }
            return sum;
        }

        /// <summary>Валовая прибыль по чеку: выручка минус себестоимость.</summary>
        public decimal GetGrossProfit()
        {
            return GetAmount() - GetCostOfGoods();
        }

        public override string GetDescription()
        {
            return $"Чек, позиций: {lines.Count}; оплата: {Localizer.Name(payment).ToLower()}";
        }

        public override void Validate()
        {
            if (Employee == null)
            {
                throw new ValidationException("Следует указать сотрудника, оформившего операцию.");
            }
            if (lines.Count == 0)
            {
                throw new ValidationException("Чек должен содержать хотя бы одну позицию.");
            }
        }

        protected override string[] GetSpecificFields()
        {
            List<string> items = new List<string>();
            foreach (OrderLine line in lines)
            {
                items.Add(line.ToRecord());
            }
            return new[]
            {
                ((int)payment).ToString(),
                RecordFormat.FormatDecimal(discountPercent),
                string.Join(RecordFormat.ItemSeparator.ToString(), items)
            };
        }
    }
}
