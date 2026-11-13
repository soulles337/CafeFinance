using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Блюдо или напиток из меню кафе с продажной ценой и себестоимостью.</summary>
    public class Dish : CatalogEntity
    {
        private DishCategory category;
        private decimal price;
        private decimal cost;

        public Dish()
        {
            category = DishCategory.Other;
        }

        public Dish(int id, string name, DishCategory category, decimal price, decimal cost)
            : base(id, name)
        {
            this.category = category;
            Price = price;
            Cost = cost;
            Validate();
        }

        public Dish(string[] parts) : base(parts)
        {
            RecordFormat.RequireFields(parts, 6);
            category = RecordFormat.ParseEnum<DishCategory>(parts[3], "Категория");
            Price = RecordFormat.ParseDecimal(parts[4], "Цена");
            Cost = RecordFormat.ParseDecimal(parts[5], "Себестоимость");
            Validate();
        }

        public DishCategory Category
        {
            get { return category; }
            set { category = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = Validator.RequirePositive(value, "Цена"); }
        }

        public decimal Cost
        {
            get { return cost; }
            set { cost = Validator.RequireNonNegative(value, "Себестоимость"); }
        }

        /// <summary>Проверяет согласованность цены и себестоимости.</summary>
        public void Validate()
        {
            if (cost > price)
            {
                throw new ValidationException("Себестоимость блюда не может превышать его цену.");
            }
        }

        /// <summary>Маржа с одной порции: цена минус себестоимость.</summary>
        public decimal GetMargin()
        {
            return price - cost;
        }

        /// <summary>Копирует значения полей из другого блюда (после успешной проверки).</summary>
        public void Assign(Dish other)
        {
            Name = other.Name;
            category = other.category;
            price = other.price;
            cost = other.cost;
        }

        public override string ToRecord()
        {
            return RecordFormat.Join("MENU", Id.ToString(), RecordFormat.Escape(Name),
                ((int)category).ToString(), RecordFormat.FormatDecimal(price), RecordFormat.FormatDecimal(cost));
        }
    }
}
