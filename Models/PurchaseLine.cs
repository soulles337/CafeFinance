using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Строка накладной на закупку: товар, единица измерения, количество, цена.</summary>
    public class PurchaseLine : LineItem
    {
        private string unit = string.Empty;

        public PurchaseLine(string name, string unit, decimal quantity, decimal unitPrice)
            : base(name, unitPrice, quantity)
        {
            Unit = unit;
        }

        public string Unit
        {
            get { return unit; }
            set { unit = Validator.RequireText(value, "Единица измерения", 10); }
        }

        public override string ToRecord()
        {
            char s = RecordFormat.SubSeparator;
            return string.Join(s.ToString(), RecordFormat.Escape(Name), RecordFormat.Escape(unit),
                RecordFormat.FormatQuantity(Quantity), RecordFormat.FormatDecimal(UnitPrice));
        }

        public static PurchaseLine FromRecord(string text)
        {
            string[] p = text.Split(RecordFormat.SubSeparator);
            if (p.Length != 4)
            {
                throw new DataFileException("Строка накладной должна содержать 4 поля: «" + text + "».");
            }
            return new PurchaseLine(RecordFormat.Unescape(p[0]), RecordFormat.Unescape(p[1]),
                RecordFormat.ParseDecimal(p[2], "Количество"),
                RecordFormat.ParseDecimal(p[3], "Цена"));
        }

        public override string ToString()
        {
            return Name + " — " + Quantity + " " + unit;
        }
    }
}
