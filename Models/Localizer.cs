using System;
using System.Collections.Generic;

namespace CafeFinance.Models
{
    /// <summary>
    /// Преобразует значения перечислений в русскоязычные названия для интерфейса и отчётов.
    /// </summary>
    public static class Localizer
    {
        private static readonly Dictionary<object, string> names = new Dictionary<object, string>
        {
            { OperationKind.Income, "Доход" },
            { OperationKind.Expense, "Расход" },

            { PaymentMethod.Cash, "Наличные" },
            { PaymentMethod.Card, "Банковская карта" },

            { DishCategory.FirstCourse, "Первые блюда" },
            { DishCategory.MainCourse, "Вторые блюда" },
            { DishCategory.Salad, "Салаты" },
            { DishCategory.Bakery, "Выпечка" },
            { DishCategory.Drink, "Напитки" },
            { DishCategory.Other, "Прочее" },

            { ExpenseCategory.Rent, "Аренда" },
            { ExpenseCategory.Utilities, "Коммунальные услуги" },
            { ExpenseCategory.Salary, "Заработная плата" },
            { ExpenseCategory.Equipment, "Оборудование и инвентарь" },
            { ExpenseCategory.Other, "Прочие расходы" },

            { EmployeePosition.Cashier, "Кассир" },
            { EmployeePosition.Cook, "Повар" },
            { EmployeePosition.Manager, "Заведующий" },
            { EmployeePosition.Accountant, "Бухгалтер" },

            { SortField.Date, "По дате" },
            { SortField.Amount, "По сумме" },
            { SortField.Type, "По типу операции" },
            { SortField.Employee, "По сотруднику" }
        };

        /// <summary>Возвращает русское название значения перечисления.</summary>
        public static string Name(object value)
        {
            string text;
            return names.TryGetValue(value, out text) ? text : value.ToString();
        }

        /// <summary>Формирует список элементов для привязки к ComboBox.</summary>
        public static List<EnumItem<T>> Items<T>() where T : struct
        {
            List<EnumItem<T>> list = new List<EnumItem<T>>();
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                list.Add(new EnumItem<T>(value, Name(value)));
            }
            return list;
        }
    }
}
