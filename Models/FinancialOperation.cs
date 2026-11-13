using System;
using System.Collections.Generic;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>
    /// Абстрактная финансовая операция кафе. Содержит общие для всех операций данные
    /// (номер, дата, ответственный сотрудник, комментарий). Особенности расчёта суммы,
    /// проверки и записи в файл определяются в производных классах (полиморфизм).
    /// </summary>
    public abstract class FinancialOperation : IFileRecord
    {
        private int id;
        private DateTime date;
        private Employee employee;
        private string comment = string.Empty;

        protected FinancialOperation()
        {
            date = DateTime.Now;
        }

        protected FinancialOperation(int id, DateTime date, Employee employee, string comment)
        {
            Id = id;
            Date = date;
            Employee = employee;
            Comment = comment;
        }

        /// <summary>Конструктор разбора записи файла: общие поля находятся в позициях 1–4.</summary>
        protected FinancialOperation(string[] parts, CafeData data)
        {
            RecordFormat.RequireFields(parts, 5);
            Id = RecordFormat.ParseInt(parts[1], "Номер операции");
            Date = RecordFormat.ParseDate(parts[2], "Дата");

            int employeeId = RecordFormat.ParseInt(parts[3], "Сотрудник");
            Employee found = data.Employees.FindById(employeeId);
            if (found == null)
            {
                throw new DataFileException($"Сотрудник с номером {employeeId} не найден в справочнике.");
            }
            Employee = found;
            Comment = RecordFormat.Unescape(parts[4]);
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new ValidationException("Номер операции не может быть отрицательным.");
                }
                id = value;
            }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = Validator.RequireDate(value); }
        }

        public Employee Employee
        {
            get { return employee; }
            set
            {
                if (value == null)
                {
                    throw new ValidationException("Следует указать сотрудника, оформившего операцию.");
                }
                employee = value;
            }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = Validator.OptionalText(value, "Комментарий", 200); }
        }

        /// <summary>Вид операции: приход или расход.</summary>
        public abstract OperationKind Kind { get; }

        /// <summary>Название типа операции для отображения (Продажа, Закупка, Расход).</summary>
        public abstract string TypeName { get; }

        /// <summary>Признак типа операции в файле данных.</summary>
        protected abstract string RecordTag { get; }

        /// <summary>Сумма операции (всегда неотрицательная).</summary>
        public abstract decimal GetAmount();

        /// <summary>Краткое описание операции для таблицы журнала.</summary>
        public abstract string GetDescription();

        /// <summary>Проверяет полноту и корректность операции перед сохранением в журнал.</summary>
        public abstract void Validate();

        /// <summary>Поля, специфичные для конкретного типа операции.</summary>
        protected abstract string[] GetSpecificFields();

        /// <summary>Сумма со знаком: доходы положительные, расходы отрицательные.</summary>
        public decimal GetSignedAmount()
        {
            return Kind == OperationKind.Income ? GetAmount() : -GetAmount();
        }

        /// <summary>Шаблонный метод: общая часть записи + поля производного класса.</summary>
        public string ToRecord()
        {
            List<string> fields = new List<string>
            {
                RecordTag,
                id.ToString(),
                RecordFormat.FormatDate(date),
                employee.Id.ToString(),
                RecordFormat.Escape(comment)
            };
            fields.AddRange(GetSpecificFields());
            return RecordFormat.Join(fields.ToArray());
        }

        public override string ToString()
        {
            return $"{TypeName} №{id} от {date:dd.MM.yyyy} — {GetAmount():N2}";
        }
    }
}
