using System;
using System.Collections.Generic;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Закупка продуктов и сырья у поставщика: расход кафе.</summary>
    public class PurchaseOperation : FinancialOperation
    {
        private readonly List<PurchaseLine> lines = new List<PurchaseLine>();
        private Supplier supplier;
        private string invoiceNumber = string.Empty;

        public PurchaseOperation()
        {
        }

        public PurchaseOperation(int id, DateTime date, Employee employee, string comment,
                                 Supplier supplier, string invoiceNumber)
            : base(id, date, employee, comment)
        {
            Supplier = supplier;
            InvoiceNumber = invoiceNumber;
        }

        public PurchaseOperation(string[] parts, CafeData data) : base(parts, data)
        {
            RecordFormat.RequireFields(parts, 8);
            int supplierId = RecordFormat.ParseInt(parts[5], "Поставщик");
            Supplier found = data.Suppliers.FindById(supplierId);
            if (found == null)
            {
                throw new DataFileException($"Поставщик с номером {supplierId} не найден в справочнике.");
            }
            Supplier = found;
            InvoiceNumber = RecordFormat.Unescape(parts[6]);
            foreach (string item in parts[7].Split(RecordFormat.ItemSeparator))
            {
                if (item.Length > 0)
                {
                    lines.Add(PurchaseLine.FromRecord(item));
                }
            }
        }

        public Supplier Supplier
        {
            get { return supplier; }
            set
            {
                if (value == null)
                {
                    throw new ValidationException("Следует указать поставщика.");
                }
                supplier = value;
            }
        }

        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = Validator.OptionalText(value, "Номер накладной", 30); }
        }

        public IReadOnlyList<PurchaseLine> Lines
        {
            get { return lines; }
        }

        public override OperationKind Kind
        {
            get { return OperationKind.Expense; }
        }

        public override string TypeName
        {
            get { return "Закупка"; }
        }

        protected override string RecordTag
        {
            get { return "PURCH"; }
        }

        public void AddLine(PurchaseLine line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }
            lines.Add(line);
        }

        public bool RemoveLine(PurchaseLine line)
        {
            return lines.Remove(line);
        }

        public override decimal GetAmount()
        {
            decimal sum = 0;
            foreach (PurchaseLine line in lines)
            {
                sum += line.GetTotal();
            }
            return sum;
        }

        public override string GetDescription()
        {
            string name = supplier == null ? "—" : supplier.Name;
            return $"Закупка у «{name}», позиций: {lines.Count}";
        }

        public override void Validate()
        {
            if (Employee == null)
            {
                throw new ValidationException("Следует указать сотрудника, оформившего операцию.");
            }
            if (supplier == null)
            {
                throw new ValidationException("Следует указать поставщика.");
            }
            if (lines.Count == 0)
            {
                throw new ValidationException("Накладная должна содержать хотя бы одну позицию.");
            }
        }

        protected override string[] GetSpecificFields()
        {
            List<string> items = new List<string>();
            foreach (PurchaseLine line in lines)
            {
                items.Add(line.ToRecord());
            }
            return new[]
            {
                supplier.Id.ToString(),
                RecordFormat.Escape(invoiceNumber),
                string.Join(RecordFormat.ItemSeparator.ToString(), items)
            };
        }
    }
}
