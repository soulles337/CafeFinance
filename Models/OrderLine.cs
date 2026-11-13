using System;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>
    /// Строка чека продажи. Хранит копию цены и себестоимости блюда на момент продажи,
    /// поэтому последующее изменение меню не искажает уже оформленные чеки.
    /// </summary>
    public class OrderLine : LineItem
    {
        private decimal unitCost;

        public OrderLine(string name, decimal unitPrice, decimal unitCost, decimal quantity)
            : base(name, unitPrice, quantity)
        {
            UnitCost = unitCost;
        }

        public OrderLine(Dish dish, decimal quantity)
            : this(dish.Name, dish.Price, dish.Cost, quantity)
        {
        }

        public decimal UnitCost
        {
            get { return unitCost; }
            set { unitCost = Validator.RequireNonNegative(value, "Себестоимость"); }
        }

        /// <summary>Себестоимость всей строки.</summary>
        public decimal GetCostTotal()
        {
            return Math.Round(Quantity * unitCost, 2, MidpointRounding.AwayFromZero);
        }

        public OrderLine Clone()
        {
            return new OrderLine(Name, UnitPrice, unitCost, Quantity);
        }

        public override string ToRecord()
        {
            char s = RecordFormat.SubSeparator;
            return string.Join(s.ToString(), RecordFormat.Escape(Name), RecordFormat.FormatDecimal(UnitPrice),
                RecordFormat.FormatDecimal(unitCost), RecordFormat.FormatQuantity(Quantity));
        }

        public static OrderLine FromRecord(string text)
        {
            string[] p = text.Split(RecordFormat.SubSeparator);
            if (p.Length != 4)
            {
                throw new DataFileException("Строка чека должна содержать 4 поля: «" + text + "».");
            }
            return new OrderLine(RecordFormat.Unescape(p[0]),
                RecordFormat.ParseDecimal(p[1], "Цена"),
                RecordFormat.ParseDecimal(p[2], "Себестоимость"),
                RecordFormat.ParseDecimal(p[3], "Количество"));
        }

        public override string ToString()
        {
            return Name + " × " + Quantity;
        }
    }
}
