using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>Сотрудник кафе, ответственный за проведение финансовых операций.</summary>
    public class Employee : CatalogEntity
    {
        private EmployeePosition position;

        public Employee()
        {
            position = EmployeePosition.Cashier;
        }

        public Employee(int id, string name, EmployeePosition position) : base(id, name)
        {
            this.position = position;
        }

        public Employee(string[] parts) : base(parts)
        {
            RecordFormat.RequireFields(parts, 4);
            position = RecordFormat.ParseEnum<EmployeePosition>(parts[3], "Должность");
        }

        public EmployeePosition Position
        {
            get { return position; }
            set { position = value; }
        }

        public override string ToRecord()
        {
            return RecordFormat.Join("EMP", Id.ToString(), RecordFormat.Escape(Name), ((int)position).ToString());
        }
    }
}
