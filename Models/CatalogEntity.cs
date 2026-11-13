using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.Models
{
    /// <summary>
    /// Абстрактная сущность справочника (блюдо, сотрудник, поставщик):
    /// имеет номер и наименование и умеет записывать себя в файл.
    /// </summary>
    public abstract class CatalogEntity : IFileRecord
    {
        private int id;
        private string name = string.Empty;

        protected CatalogEntity()
        {
        }

        protected CatalogEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>Конструктор разбора записи файла: поля 1 и 2 — номер и наименование.</summary>
        protected CatalogEntity(string[] parts)
        {
            RecordFormat.RequireFields(parts, 3);
            Id = RecordFormat.ParseInt(parts[1], "Номер");
            Name = RecordFormat.Unescape(parts[2]);
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    throw new ValidationException("Номер записи не может быть отрицательным.");
                }
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = Validator.RequireText(value, "Наименование", 100); }
        }

        public abstract string ToRecord();

        public override string ToString()
        {
            return name;
        }
    }
}
