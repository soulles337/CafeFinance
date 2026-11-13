using System;

namespace CafeFinance.Models
{
    /// <summary>
    /// Все данные приложения: справочники блюд, сотрудников, поставщиков и журнал операций.
    /// Объект целиком загружается из файла и записывается в файл.
    /// </summary>
    public class CafeData
    {
        private readonly Catalog<Dish> dishes = new Catalog<Dish>();
        private readonly Catalog<Employee> employees = new Catalog<Employee>();
        private readonly Catalog<Supplier> suppliers = new Catalog<Supplier>();
        private readonly OperationJournal journal = new OperationJournal();

        public Catalog<Dish> Dishes
        {
            get { return dishes; }
        }

        public Catalog<Employee> Employees
        {
            get { return employees; }
        }

        public Catalog<Supplier> Suppliers
        {
            get { return suppliers; }
        }

        public OperationJournal Journal
        {
            get { return journal; }
        }

        /// <summary>Возвращает сотрудника из справочника или создаёт нового (без добавления в справочник).</summary>
        public Employee FindOrCreateEmployee(string name)
        {
            Employee found = employees.FindByName(name);
            return found ?? new Employee(0, name, EmployeePosition.Cashier);
        }

        /// <summary>Возвращает поставщика из справочника или создаёт нового (без добавления в справочник).</summary>
        public Supplier FindOrCreateSupplier(string name)
        {
            Supplier found = suppliers.FindByName(name);
            return found ?? new Supplier(0, name, string.Empty);
        }

        /// <summary>Добавляет сотрудника в справочник, если его там ещё нет.</summary>
        public void RegisterEmployee(Employee employee)
        {
            if (employees.FindByName(employee.Name) == null)
            {
                employees.Add(employee);
            }
        }

        /// <summary>Добавляет поставщика в справочник, если его там ещё нет.</summary>
        public void RegisterSupplier(Supplier supplier)
        {
            if (suppliers.FindByName(supplier.Name) == null)
            {
                suppliers.Add(supplier);
            }
        }

        /// <summary>Создаёт набор данных с типовыми справочниками (без операций).</summary>
        public static CafeData CreateDefault()
        {
            CafeData data = new CafeData();

            data.employees.Add(new Employee(0, "Иванова А. П.", EmployeePosition.Cashier));
            data.employees.Add(new Employee(0, "Петров С. И.", EmployeePosition.Manager));
            data.employees.Add(new Employee(0, "Сидорова Е. В.", EmployeePosition.Accountant));

            data.suppliers.Add(new Supplier(0, "Овощная база", "+375 165 00-00-01"));
            data.suppliers.Add(new Supplier(0, "Молочный комбинат", "+375 165 00-00-02"));
            data.suppliers.Add(new Supplier(0, "Мясокомбинат", "+375 165 00-00-03"));

            data.dishes.Add(new Dish(0, "Борщ", DishCategory.FirstCourse, 2.50m, 1.10m));
            data.dishes.Add(new Dish(0, "Суп куриный", DishCategory.FirstCourse, 2.20m, 0.95m));
            data.dishes.Add(new Dish(0, "Котлета с гарниром", DishCategory.MainCourse, 4.20m, 2.10m));
            data.dishes.Add(new Dish(0, "Макароны с сосиской", DishCategory.MainCourse, 3.40m, 1.60m));
            data.dishes.Add(new Dish(0, "Салат овощной", DishCategory.Salad, 1.80m, 0.80m));
            data.dishes.Add(new Dish(0, "Пирожок с капустой", DishCategory.Bakery, 0.90m, 0.35m));
            data.dishes.Add(new Dish(0, "Чай", DishCategory.Drink, 0.70m, 0.15m));
            data.dishes.Add(new Dish(0, "Кофе", DishCategory.Drink, 1.50m, 0.50m));
            data.dishes.Add(new Dish(0, "Компот", DishCategory.Drink, 0.80m, 0.25m));

            return data;
        }

        /// <summary>Создаёт демонстрационный набор: справочники и операции за две недели.</summary>
        public static CafeData CreateDemo()
        {
            CafeData data = CreateDefault();
            Random random = new Random(2026);
            Employee cashier = data.employees.FindByName("Иванова А. П.");
            Employee manager = data.employees.FindByName("Петров С. И.");

            for (int day = 13; day >= 0; day--)
            {
                DateTime date = DateTime.Today.AddDays(-day);
                for (int shift = 0; shift < 4; shift++)
                {
                    data.journal.Add(CreateDemoSale(data, random, date.AddHours(9 + shift * 2), cashier));
                }
                if (day % 4 == 0)
                {
                    data.journal.Add(CreateDemoPurchase(data, random, date.AddHours(8), manager));
                }
            }

            data.journal.Add(new ExpenseOperation(0, DateTime.Today.AddDays(-12), manager,
                "Аренда помещения за месяц", ExpenseCategory.Rent, 600m));
            data.journal.Add(new ExpenseOperation(0, DateTime.Today.AddDays(-9), manager,
                "Коммунальные услуги за месяц", ExpenseCategory.Utilities, 180m));
            data.journal.Add(new ExpenseOperation(0, DateTime.Today.AddDays(-5), manager,
                "Заработная плата персонала", ExpenseCategory.Salary, 1500m));
            return data;
        }

        private static SaleOperation CreateDemoSale(CafeData data, Random random, DateTime date, Employee cashier)
        {
            PaymentMethod method = random.Next(2) == 0 ? PaymentMethod.Cash : PaymentMethod.Card;
            SaleOperation sale = new SaleOperation(0, date, cashier, string.Empty, method, 0);
            int positions = random.Next(1, 4);
            for (int i = 0; i < positions; i++)
            {
                Dish dish = data.dishes[random.Next(data.dishes.Count)];
                sale.AddLine(new OrderLine(dish, random.Next(1, 4)));
            }
            return sale;
        }

        private static PurchaseOperation CreateDemoPurchase(CafeData data, Random random, DateTime date, Employee manager)
        {
            Supplier supplier = data.suppliers[random.Next(data.suppliers.Count)];
            PurchaseOperation purchase = new PurchaseOperation(0, date, manager, string.Empty,
                supplier, "ТН-" + random.Next(100, 999));
            purchase.AddLine(new PurchaseLine("Картофель", "кг", random.Next(20, 60), 1.20m));
            purchase.AddLine(new PurchaseLine("Мука", "кг", random.Next(10, 30), 1.80m));
            purchase.AddLine(new PurchaseLine("Мясо охлаждённое", "кг", random.Next(8, 25), 12.50m));
            return purchase;
        }
    }
}
